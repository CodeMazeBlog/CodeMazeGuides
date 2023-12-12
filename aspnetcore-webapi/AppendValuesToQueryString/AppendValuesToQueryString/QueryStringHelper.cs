using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Collections.Specialized;
using System.Web;

namespace AppendValuesToQueryString
{
    public static class QueryStringHelper
    {
        private static NameValueCollection AppendOrUpdateQueryStringUsingParseQueryString(string url, Dictionary<string, string> queryParams)
        {

            var uriBuilder = new UriBuilder(url);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach ( var kvp in queryParams )
            {
                query.Set(kvp.Key, kvp.Value);
            }

            return query;
        }

        public static string CreateURLUsingParseQueryString(string url, Dictionary<string, string> queryParams)
        {
            var queryString = AppendOrUpdateQueryStringUsingParseQueryString(url, queryParams);

            return $"{url.Split('?')[0]}?{queryString}";
        }

        private static Dictionary<string, StringValues> AppendOrUpdateQueryStringUsingParseQuery(string url, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(url);

            var query = QueryHelpers.ParseQuery(uriBuilder.Query);

            foreach (var kvp in queryParams)
            {
                query[kvp.Key] = kvp.Value;
            }

            return query;
        }

        public static string CreateURLUsingParseQuery(string url, Dictionary<string, string> queryParams)
        {
            var queryString = AppendOrUpdateQueryStringUsingParseQuery(url, queryParams);

            return QueryHelpers.AddQueryString(url.Split('?')[0], queryString);
        }

        private static string AppendQueryStringUsingAddQueryString(string url, Dictionary<string, string?> queryParams)
        {
            var modifiedUrl = QueryHelpers.AddQueryString(url, queryParams);

            return modifiedUrl;
        }

        public static string CreateURLUsingAddQueryString(string url, Dictionary<string, string?> queryParams)
        {
            var queryString = AppendQueryStringUsingAddQueryString(url, queryParams);

            return queryString;
        }
    }
}
