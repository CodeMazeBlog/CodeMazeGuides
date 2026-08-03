using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System.Web;

namespace BuildQueryString
{
    public static class QueryStringHelper
    {
        public static string BuildUrlWithQueryStringUsingStringConcat(
            string basePath, Dictionary<string, string> queryParams)
        {
            var queryString = string.Join("&", queryParams.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));

            var fullApiUrl = $"{basePath}?{queryString}";
            Console.WriteLine(fullApiUrl);

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingUriBuilder(string basePath, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(basePath)
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };

            var fullApiUrl = uriBuilder.Uri.AbsoluteUri;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingParseQueryStringMethod(
            string basePath, Dictionary<string, string> queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var dict in queryParams)
            {
                query[dict.Key] = dict.Value;
            }

            var fullApiUrl = string.Join("?", basePath, query.ToString());
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingAddQueryStringMethod(
            string basePath, Dictionary<string, string?> queryParams)
        {
            var fullApiUrl = QueryHelpers.AddQueryString(basePath, queryParams);
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingQueryBuilderClass(
            string basePath, Dictionary<string, string> queryParams)
        {
            var queryBuilder = new QueryBuilder(queryParams);

            var fullApiUrl = basePath + queryBuilder;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingCreateMethod(
            string basePath, Dictionary<string, string?> queryParams)
        {
            var queryString = QueryString.Create(queryParams);

            var fullApiUrl = basePath + queryString;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }
    }
}
