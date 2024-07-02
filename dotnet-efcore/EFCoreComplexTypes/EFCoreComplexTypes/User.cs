namespace EFCoreComplexTypes;

public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required Address Address { get; set; }
}