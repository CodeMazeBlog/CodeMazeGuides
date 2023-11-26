namespace SerializeObjectToQueryString
{
    public class Product
    {
        public string Name { get; set; } = "Laptop";
        public string Category { get; set; } = "Electronics";
        public Manufacturer Manufacturer { get; set; } = new Manufacturer();
    }

    public class Manufacturer
    {
        public string Location { get; set; } = "Silicon Valley";
    }
}