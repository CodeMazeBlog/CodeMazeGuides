namespace EqualityOperatorVsEqualsMethodInCSharp.Records
{
    public record Laptop
    {
        public string Model { get; init; }
        public int Price { get; init; }

        public Laptop(string model, int price)
        {
            Model = model;
            Price = price;
        }
    }
}
