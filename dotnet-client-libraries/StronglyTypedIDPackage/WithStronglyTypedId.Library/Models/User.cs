using StronglyTypedIds;

namespace WithStronglyTypedId.Library.Models;

[StronglyTypedId(Template.String)]
public partial struct UserId { }

public class User
{
    public UserId Id { get; set; }
    public string? Name { get; set; }
    public List<Comment>? Comments { get; set; }
}
