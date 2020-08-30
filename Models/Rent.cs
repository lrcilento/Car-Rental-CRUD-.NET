using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CRUD_Car_Rental.Models
{
    public class Rent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ClientCPF")]
        public string ClientCPF { get; set; }
        [BsonElement("StartDate")]
        public string StartDate { get; set; }
        [BsonElement("EndDate")]
        public string EndDate { get; set; }
        [BsonElement("TotalPrice")]
        public float TotalPrice  { get; set; }
        [BsonElement("CarPlate")]
        public string CarPlate { get; set; }
        [BsonElement("Status")]
        public bool Status { get; set; }
    }
}