using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace AutoMapperIgnoreProperty;

[AutoMap(typeof(User))]
public class UserDetailsDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    [Ignore]
    public string Password { get; set; }
    [Ignore]
    public bool IsAdmin { get; set; }
    public DateTime CreatedAt { get; set; }
}
