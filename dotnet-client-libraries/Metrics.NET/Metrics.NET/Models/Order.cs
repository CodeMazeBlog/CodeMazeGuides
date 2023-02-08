namespace Metrics.NET.Models;

public class Order
{
    public int Id { get; set; }

    public decimal TotalPrice { get => Items.Sum(i => i.Price); }

    public List<ComputerComponent> Items { get; set; } = new();
}
