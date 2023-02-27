namespace ExcludePropertyJsonInCSharp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!; 
        public int Classification { get; set; } = default!;
    }
}
