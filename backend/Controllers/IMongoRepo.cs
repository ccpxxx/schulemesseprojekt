using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Messe.Controllers
{
    public abstract class IMongoRepo<T>
    {
        private IMongoDatabase mongoDbRepo;
        protected bool offline;
        public IMongoRepo(string dbName)
        {
            this.offline=false;
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

        public abstract void saveCustomer(string table,T record);
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

        protected int countFiles()
        {
            int count= 0;
            DirectoryInfo d = new DirectoryInfo("./backlog");
            try 
            {  FileInfo[] Files = d.GetFiles("*.json");
                count=Files.Length;
            }catch { }
           
           
            return count;
        }

        protected List<Customer> getContentOfLocalFiles()
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
   
}
