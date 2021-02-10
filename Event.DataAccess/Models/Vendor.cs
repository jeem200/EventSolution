using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Event.DataAccess.Models
{
    public class VendorModel
    {
        //[FromForm]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("VendorName")]
        public string VendorName { get; set; }

        [BsonElement("Rating")]
        public int Rating { get; set; }

        [BsonElement("VideoLocation")]
        public string VideoLocation { get; set; }

        [BsonElement("NoOfCollab")]
        public int NoOfCollab { get; set; }

        [BsonElement("ServiceType")]
        public List<ServiceTypeModel> ServiceType { get; set; }



    }
}
