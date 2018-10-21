using MongoDB.Bson.Serialization.Attributes;

namespace Kube.Api.Models
{
    public class Book : BaseModel
    {
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("author")]
        public string Author { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
    }
}