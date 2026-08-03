namespace WithoutStronglyTypedId.Library.Models;

public class User
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public List<Comment>? Comments { get; set; }
}
