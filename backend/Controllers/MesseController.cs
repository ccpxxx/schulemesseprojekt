using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Messe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MesseController : ControllerBase
    {
        public IConfiguration configuration { get; }
        private IMongoRepo<Customer> rep;
        private string table;

        public MesseController(IConfiguration configuration)
        {
            this.configuration = configuration;
            rep = new MongoRepoImpl("Records");
            table = "Customer";
        }

        [HttpGet("getUsers")]
        [EnableCors("CorsApi")]
        public IActionResult getUsers()
        {
            return Ok(rep.getAllFromDb(this.table));
        }

        [HttpPost("submitCustomer")]
        [EnableCors("CorsApi")]
        public IActionResult submitCustomer([FromBody] Customer customer)
        {
            rep.saveToDb(this.table, customer);
            return Ok();
        }
        [HttpGet("getSpecificUser")]
        [EnableCors("CorsApi")]
        public IActionResult getSpecificUser()
        {
           return Ok();
        }

    }
    public abstract class IMongoRepo<T>
    {
        private IMongoDatabase mongoDbRepo;
        protected bool offline;
        public IMongoRepo(string dbName)
        {
            offline=false;
            var client = new MongoClient("mongodb://localhost:27017?connectTimeoutMS=5000&serverSelectionTryOnce=true&serverSelectionTimeoutMS=1000");
            try
            {
                client.StartSession();
            }
            catch (Exception ex)
            {
                offline = true;
            }
            
            mongoDbRepo = client.GetDatabase(dbName);
            

        }

        public abstract void saveToDb(string table,T record);
        public abstract List<T> getAllFromDb(string table);

        protected IMongoDatabase getMongoRepo()
        {
            return this.mongoDbRepo;
        }

        protected int getMaxId<T>(string table)
        {
            var collection = mongoDbRepo.GetCollection<T>(table);
            var filter = Builders<T>.Sort.Descending("id");
            var res = collection.Find(new BsonDocument()).Sort(filter).FirstOrDefault();
            try { return BsonSerializer.Deserialize<Customer>(res.ToBson()).id; } catch { }
            return -1;
        }

        protected void saveToJson(T record)
        {
            string generic = "offline"+(countFiles()+1);
            try {
                string json = JsonSerializer.Serialize(record);
                if (!Directory.Exists("./backlog"))
                {
                    Directory.CreateDirectory("./backlog");
                }

                File.WriteAllText($"./backlog/{generic}.json", json);

            }
            catch { }
        }

        private int countFiles()
        {
            int count= 0;
            DirectoryInfo d = new DirectoryInfo("./backlog");
            try 
            {  FileInfo[] Files = d.GetFiles("*.json");
                count=Files.Length;
            }catch { }
           
           
            return count;
        }

        protected List<Customer> getContentOfAllFiles()
        {
            List<Customer> res = new List<Customer>();
            try { 
            foreach (string file in Directory.EnumerateFiles("./backlog", "*.json"))
            {
                res.Add(JsonSerializer.Deserialize<Customer>(File.ReadAllText(file)));
            }
            }catch { }
            return res;
        }

        protected void deleteBacklog()
        {
            if (Directory.Exists("./backlog"))
            {
                Directory.Delete("./backlog",true);
            }
        }

    }

    public class MongoRepoImpl : IMongoRepo<Customer>
    {
        public MongoRepoImpl(string dbName) : base(dbName)
        {
        }

        public override List<Customer> getAllFromDb(string table)
        {
            var result = getMongoRepo().GetCollection<Customer>(table).Find(new BsonDocument());
            return result.ToList();
        }

        public override void saveToDb(string table, Customer record)
        {
            if (!offline)
            {
                List<Customer> batch = new List<Customer>();
                batch.Add(record);
                if (getContentOfAllFiles().Count > 0)
                {
                    batch.AddRange(getContentOfAllFiles());
                }
                foreach(Customer cust in batch)
                {
                    int highest = this.getMaxId<Customer>(table);
                    if (highest > -1 || cust.id == -1)
                    {
                        cust.id = highest + 1;
                    }
                    getMongoRepo().GetCollection<Customer>(table).InsertOne(cust);

                }
                deleteBacklog();
            }
            else 
            {
                record.id = -1;
                saveToJson(record); 
            }

        }
    }
   
}
