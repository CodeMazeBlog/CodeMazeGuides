namespace MultipleParametersInGetMethod.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public string? Name { get; set; }
        public int WarrantyYears { get; set; }
        public bool IsAvailable { get; set; }
    }
}
