namespace GenerateUniqueIDsWithNewId.Contracts;

public class OrderForUpdateDto
{
    public required string CustomerName { get; set; }
    public required List<string> Products { get; set; }
    public required decimal TotalAmount { get; set; }
}
