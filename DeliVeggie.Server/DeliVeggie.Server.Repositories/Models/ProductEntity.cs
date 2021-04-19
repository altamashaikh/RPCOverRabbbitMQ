using MongoDB.Bson.Serialization.Attributes;
using System;

namespace DeliVeggie.Server.Repositories.Models
{
    public class ProductEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public DateTime EntryDate { get; set; }
        public double Price { get; set; }
    }
}
