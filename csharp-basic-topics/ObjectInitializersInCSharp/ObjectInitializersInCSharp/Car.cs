namespace ObjectInitializersInCSharp
{
    public class Car
    {
        public string Make { get; set; } = "Unknown Make";
        public string Model { get; set; } = "Unknown Model";
        public string Description { get; set; }

        public Car(string make, string model)
        {
            Make = make;
            Model = model;
            Description = GetCarDescription();
        }

        private string GetCarDescription()
        {
            return $"This is a {Make} {Model}.";
        }
    }
}
