using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD_Car_Rental.Models
{
    public class Car
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Plate")]
        public string Plate { get; set; }
        [BsonElement("Year")]
        public int Year { get; set; }
        [BsonElement("Color")]
        public string Color { get; set; }
        [BsonElement("DailyRate")]
        public float DailyRate { get; set; }
        [BsonElement("Status")]
        public bool Status { get; set; }

    }
}
