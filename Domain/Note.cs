namespace Domain;

public class Note : IEntity
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
}