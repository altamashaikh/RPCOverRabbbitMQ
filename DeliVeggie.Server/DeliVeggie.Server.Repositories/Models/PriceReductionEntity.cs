using MongoDB.Bson.Serialization.Attributes;

namespace DeliVeggie.Server.Repositories.Models
{
    public class PriceReductionEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public int DayOfWeek { get; set; }
        public double Reduction { get; set; }
    }
}
