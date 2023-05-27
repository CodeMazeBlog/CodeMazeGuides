namespace WireMock.NET.Tests.Contracts
{
    public class Planet
    {
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int NumberOfMoons { get; set; }
        public bool HasAtmosphere { get; set; }

        public Planet(
            string name,
            double diameter,
            int numberOfMoons,
            bool hasAtmosphere)
        {
            Name = name;
            Diameter = diameter;
            NumberOfMoons = numberOfMoons;
            HasAtmosphere = hasAtmosphere;
        }
    }
}
