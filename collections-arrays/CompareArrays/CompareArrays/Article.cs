namespace CompareArrays
{
    public class Article
    {
        public string? Title { get; set; }
        public DateTime LastUpdate { get; set; }
    }

    public class ArticleComparer : IEqualityComparer<Article>
    {
        public bool Equals(Article? first, Article? second)
        {
            if (ReferenceEquals(first, second))
                return true;

            if (first is null || second is null)
                return false;

            return first.Title == second.Title && first.LastUpdate == second.LastUpdate;
        }

        public int GetHashCode(Article obj)
        {
            return HashCode.Combine(obj.Title, obj.LastUpdate);
        }
    }
}
