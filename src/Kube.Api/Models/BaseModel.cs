using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kube.Api.Models
{
    public class BaseModel
    {
        [BsonId]
        [BsonElement("id")]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }
    }
}