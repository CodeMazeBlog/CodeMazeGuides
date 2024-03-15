namespace TheForEachMethodAndForeachStatement;

public class Product
{
    public Guid Id { get; set; }
    public int Price { get; set; }

    public Product(int price)
    {
        Id = Guid.NewGuid();
        Price = price;
    }
}
