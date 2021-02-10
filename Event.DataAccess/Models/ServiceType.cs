using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccess.Models
{
    public class ServiceTypeModel
    {
       
        //[BsonId]
        //public ObjectId Id { get; set; }

        [BsonElement("ServiceName")]
        public string ServiceName { get; set; }

        [BsonElement("MinPrice")]
        public int MinPrice { get; set; }

        [BsonElement("MaxPrice")]
        public int MaxPrice { get; set; }
    }
}
