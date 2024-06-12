namespace EFCoreComplexTypes;

public record User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required Address Address { get; set; }
}