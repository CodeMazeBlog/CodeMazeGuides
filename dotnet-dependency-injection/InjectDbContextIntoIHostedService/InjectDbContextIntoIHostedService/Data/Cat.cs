namespace InjectDbContextIntoIHostedService.Data;

public class Cat
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int Age { get; set; }
}
