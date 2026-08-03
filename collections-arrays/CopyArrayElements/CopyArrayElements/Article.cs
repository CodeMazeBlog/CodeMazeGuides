namespace CopyArrayElements
{
    public class Article
    {
        public string? Title { get; set; }
        public DateTime LastUpdate { get; set; }

        public override string ToString()
        {
            return $"   Title: { Title} | Last update:{LastUpdate}";
        }
    }
}
