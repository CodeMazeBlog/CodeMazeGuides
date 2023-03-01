namespace ExcludePropertyJsonInCSharp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? Pages { get; set; }
        public int Sells { get; set; }
        public Author? Author { get; set; }
    }
}
