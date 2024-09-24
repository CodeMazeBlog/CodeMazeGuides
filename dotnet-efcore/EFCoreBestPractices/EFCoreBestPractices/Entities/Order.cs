namespace EFCoreBestPractices.Entities;
public class Order
{
    public int Id { get; set; }
    public string? ProductName { get; set; }
    public int SupplierId { get; set; }
    public virtual Supplier? Supplier { get; set; }
}