namespace WireMockNet
{
    public record class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Diameter { get; set; }
        public int NumberOfMoons { get; set; }
        public bool HasAtmosphere { get; set; }
    }
}
