namespace IntroductionToScrutorInDotNet.Customers.Entities;

public class Customer
{
    public required int CustomerId { get; init; }
    public required string FullName { get; init; }
}