namespace InitSetters
{
    public class City
    {
        public string Name { get; private set; }
        public double Latitude { get; init; }
        public double Longitude { get; init; }

        public City(string name, double latitude, double longitude)
        {
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
