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

        [BsonElement("ItemName")]
        public string ItemName { get; set; }

        [BsonElement("ItemType")]
        public string ItemType { get; set; }

        [BsonElement("ItemPrice")]
        public int ItemPrice { get; set; }

        [BsonElement("ItemCode")]
        public string ItemCode { get; set; }

        [BsonElement("ItemDescription")]
        public string ItemDescription { get; set; }

        [BsonElement("ItemComponent")]

        public List<string> ItemComponent { get; set; }

        [BsonElement("MediaLocation")]
        public List<string> MediaLocation { get; set; }

        [BsonElement("MinGuest")]
        public int MinGuest { get; set; }

        [BsonElement("MaxGuest")]
        public int MaxGuest { get; set; }


    }
}
