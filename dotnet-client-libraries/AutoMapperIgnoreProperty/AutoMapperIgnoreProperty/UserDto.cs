namespace AutoMapperIgnoreProperty;

public class UserDto
{
    public int Id { get; set; }
    public string Password { get; set; }
    public bool IsAdmin { get; set; }
    public DateTime CreatedAt { get; set; }
}