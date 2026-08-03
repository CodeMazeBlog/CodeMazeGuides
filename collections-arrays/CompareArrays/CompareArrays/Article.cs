namespace CompareArrays
{
    public class Article : IEqualityComparer<Article>
    {
        public string? Title { get; set; }
        public DateTime LastUpdate { get; set; }

        public bool Equals(Article? first, Article? second)
        {
            return first?.Title == second?.Title && first?.LastUpdate == second?.LastUpdate;
        }

        public int GetHashCode(Article obj)
        {
            return base.GetHashCode();
        }
    }
}
