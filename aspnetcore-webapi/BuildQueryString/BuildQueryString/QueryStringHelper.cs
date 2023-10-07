using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System.Collections.Specialized;
using System.Web;

namespace BuildQueryString
{
    public static class QueryStringHelper
    {
        public static string BuildUrlWithQueryStringUsingStringConcat(string basePath, Dictionary<string, string> queryParams)
        {
            var queryString = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"));

            var fullApiUrl = $"{basePath}?{queryString}";
            Console.WriteLine(fullApiUrl);

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingStringConcatByEncoding(string basePath, Dictionary<string, string> queryParams)
        {
            var queryString = string.Join("&", queryParams.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={kvp.Value}"));

            var fullApiUrl = $"{basePath}?{queryString}";
            Console.WriteLine(fullApiUrl);

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingUriBuilder(string basePath, Dictionary<string, string> queryParams)
        {
            UriBuilder uriBuilder = new(basePath)
            {
                Path = "/api/Books",
                Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };

            Uri fullApiUrl = uriBuilder.Uri;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl.ToString();
        }

        public static string BuildUrlWithQueryStringUsingParseQueryStringMethod(string basePath, Dictionary<string, string> queryParams)
        {
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var dict in queryParams)
            {
                query[dict.Key] = dict.Value;
            }

            var fullApiUrl = string.Join("?", basePath, query);
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingAddQueryStringMethod(string basePath, Dictionary<string, string> queryParams)
        {
            string fullApiUrl = QueryHelpers.AddQueryString(basePath, queryParams);
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingQueryBuilderClass(string basePath, Dictionary<string, string> queryParams)
        {
            QueryBuilder queryBuilder = new QueryBuilder(queryParams);

            var fullApiUrl = basePath + queryBuilder;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildurlWithQueryStringUsingCreateMethod(string basePath, Dictionary<string, string> queryParams)
        {
            QueryString queryString = QueryString.Create(queryParams);

            var fullApiUrl = basePath + queryString;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }
    }
}
