namespace GenerateUniqueIDsWithNewId.Contracts;

public class OrderForCreationDto
{
    public required string CustomerName { get; set; }
    public required List<string> Products { get; set; }
    public required decimal TotalAmount { get; set; }
}
