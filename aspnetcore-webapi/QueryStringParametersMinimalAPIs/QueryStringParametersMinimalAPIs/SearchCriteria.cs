using System.Reflection;

namespace QueryStringParametersWithMinimalAPIs
{
    public class SearchCriteria
    {
        public string? Author { get; set; }
        public int YearPublished { get; set; }

        public static ValueTask<SearchCriteria?> BindAsync(HttpContext context, ParameterInfo parameter)
        {
            string author = context.Request.Query["Author"];
            int.TryParse(context.Request.Query["YearPublished"], out var year);

            var result = new SearchCriteria
            {
                Author = author,
                YearPublished = year
            };

            return ValueTask.FromResult<SearchCriteria?>(result);
        }
    }
}
