using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Messe.Controllers
{
    public class MongoRepoImpl : IMongoRepo<Customer>
    {
        public MongoRepoImpl(string dbName) : base(dbName)
        {
        }

        public override List<Customer> getAllFromDb(string table)
        {
            if (!offline) {
                if (countFiles() > 0)
                {
                    submitAndTidyLocal(getContentOfLocalFiles(), table);
                }
            var result = getMongoRepo().GetCollection<Customer>(table).Find(new BsonDocument());
            return result.ToList();
            }
            return new List<Customer>();
        }

        public override void saveCustomer(string table, Customer record)
        {
            if (!offline)
            {
                List<Customer> batch = new List<Customer>();
                batch.Add(record);
                if (countFiles() > 0)
                {
                    batch.AddRange(getContentOfLocalFiles());
                }
                submitAndTidyLocal(batch,table);
            }
            else 
            {
                record.id = -1;
                saveToJson(record); 
            }

        }

        private void submitAndTidyLocal(List<Customer> toSubmit,string table)
        {
            foreach (Customer cust in toSubmit)
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
       
    }
   
}
