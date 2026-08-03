namespace GenerateUniqueIDsWithNewId.Data.Models;

public class Order
{
    public required Guid Id { get; set; }
    public required string CustomerName { get; set; }
    public required List<string> Products { get; set; }
    public required decimal TotalAmount { get; set; }
}
