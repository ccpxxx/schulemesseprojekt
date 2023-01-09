using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Messe
{
    public class Customer
    {

        public string firstname { get; set; }
        public string name { get; set; }
        [BsonId]
        public int id { get; set; }
        public string picture { get; set; }

        public Customer()
        {
        }

    }
}
