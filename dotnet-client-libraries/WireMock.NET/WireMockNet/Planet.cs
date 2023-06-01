namespace WireMockNet
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int NumberOfMoons { get; set; }
        public bool HasAtmosphere { get; set; }
    
        public Planet(
            int id,
            string name,
            double diameter,
            int numberOfMoons,
            bool hasAtmosphere)
        {
            Id = id;
            Name = name;
            Diameter = diameter;
            NumberOfMoons = numberOfMoons;
            HasAtmosphere = hasAtmosphere;
        }
    }
}
