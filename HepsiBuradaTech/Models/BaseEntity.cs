using MongoDB.Bson.Serialization.Attributes;
using System;

namespace HepsiBuradaTech.Models
{
    public abstract class BaseEntity
    {
        [BsonId] public Guid Id { get; set; }
    }
}
