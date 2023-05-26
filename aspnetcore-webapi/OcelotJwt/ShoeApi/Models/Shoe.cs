namespace ShoeApi.Models
{
    public class Shoe
    {
        public required int Id { get; set; }

        public required string Name { get; set; }

        public required string Brand { get; set; }

        public decimal Price { get; set; }
    }
}
