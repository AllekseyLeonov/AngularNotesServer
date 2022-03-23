using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Core;

public class Note : IEntity
{
    [BsonId]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
}