namespace SerializationWithRootName
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
    public class CarWrapper
    {
        public Car MyCar { get; set; }
    }
}

