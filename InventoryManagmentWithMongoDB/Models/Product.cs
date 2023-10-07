using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }
    }
}
