namespace WebApiBestPractices.Domain.Entities;

public class Owner
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Address { get; set; }
}
