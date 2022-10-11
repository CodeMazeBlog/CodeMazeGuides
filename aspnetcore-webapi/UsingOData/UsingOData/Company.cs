namespace UsingOData
{
    public class Company
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int Size { get; set; }
        public List<Product>? Products { get; set; }
    }
}
