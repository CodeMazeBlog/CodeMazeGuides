namespace ReadArraysFromAppSettings;

public record User(int Id, string Name, string Role);

public record Member(int Id, string Name);

public record Group(int Id, string Name)
{
    public List<Member>? Members { get; init; }
};

public record AppSettings
{
    public List<User>? Users { get; init; }
    public List<Group>? Groups { get; init; }
};
