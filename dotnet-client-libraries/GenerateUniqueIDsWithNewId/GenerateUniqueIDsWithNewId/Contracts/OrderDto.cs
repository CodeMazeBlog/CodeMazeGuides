namespace GenerateUniqueIDsWithNewId.Contracts;

public class OrderDto
{
    public required Guid Id { get; set; }
    public required string CustomerName { get; set; }
    public required List<string> Products { get; set; }
    public required decimal TotalAmount { get; set; }
}
