namespace QueryStringParametersWithMinimalAPIs
{
    public class ArticleIDs
    {
        public List<int> IDs = new List<int>();

        public static bool TryParse(string? value, IFormatProvider? provider, out ArticleIDs? articleIDs)
        {
            var trimmedValue = value?.TrimStart('(').TrimEnd(')');
            var segments = trimmedValue?.Split(',',
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (segments == null)
            {
                articleIDs = new ArticleIDs();
                return false;
            }

            var idList = new List<int>();
            foreach (var segment in segments)
            {
                int.TryParse(segment, out int id);
                idList.Add(id);
            }

            articleIDs = new ArticleIDs()
            {
                IDs = idList
            };

            return true;
        }
    }
}
