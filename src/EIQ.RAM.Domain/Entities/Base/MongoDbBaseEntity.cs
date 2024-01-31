using System;
using System.ComponentModel.DataAnnotations.Schema;
using EIQ.RAM.Domain.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EIQ.RAM.Domain.Entities;

public class MongoDbBaseEntity : IHasCreation, IHasUpdate
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }

    [BsonElement("created_at")] public DateTime CreatedAt { get; set; }
    [BsonElement("updated_at")] public DateTime? UpdatedAt { get; set; }
}
