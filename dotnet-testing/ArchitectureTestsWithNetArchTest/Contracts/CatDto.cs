namespace Contracts;

public class CatDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Breed { get; set; }
    public required DateTime DateOfBirth { get; set; }
}
