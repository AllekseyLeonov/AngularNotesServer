namespace Domain.Core;

public class User : IEntity
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<int> SharedNotes { get; set; } = new List<int>();
}