namespace ChainOfResponsibilityPattern;

public class Book(string name, bool isReserved)
{
    public const decimal RentalFee = 15;

    public string Name { get; } = name;
    public bool IsReserved { get; } = isReserved;
    public string? IssuedTo { get; set; }
}
