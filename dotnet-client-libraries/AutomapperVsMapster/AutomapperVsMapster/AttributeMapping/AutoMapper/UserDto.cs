using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace AutomapperVsMapster.AttributeMapping.AutoMapper;

[AutoMap(typeof(User))]
public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    [SourceMember("CreatedAt")]
    public string CreatedDate { get; set; } = null!;
}