namespace GlobalDefaultJsonSerializationoptions;
public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime ReleaseDate { get; set; }
    public Manufacturer Manufacturer { get; set; } = new Manufacturer();
}

public class Manufacturer
{
    public string? Name { get; set; }
    public string? Location { get; set; }
}