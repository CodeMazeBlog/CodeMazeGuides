namespace FanIn_Fan_out.Shared.Application.DataObjects;

public class StatisticProductDTO
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;

    public int SaleQuantity { get; set; } 

    public decimal SaleTotalPrice { get; set; } 
}