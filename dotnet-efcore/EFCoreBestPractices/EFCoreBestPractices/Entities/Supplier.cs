namespace EFCoreBestPractices.Entities;
public class Supplier
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public virtual ICollection<Order>? Orders { get; set; }
}