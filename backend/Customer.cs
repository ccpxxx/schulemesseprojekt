using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Messe
{
    public class Customer
    {

        public string firstname { get; set; }
        public string name { get; set; }
        [BsonId]
        public int id { get; set; }
        public string picture { get; set; }
        public List<string> interests { get; set; }
        public string company { get; set; } 
        public Customer()
        {
        }

    }
}
