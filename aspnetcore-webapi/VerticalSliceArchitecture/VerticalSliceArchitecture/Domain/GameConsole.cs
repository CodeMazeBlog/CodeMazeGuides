namespace VerticalSliceArchitecture.Domain
{
    public class GameConsole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
