using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.Int32)]
        public int ProductId;

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("Quantity")]
        public int Quantity { get; set; }
    }
}
