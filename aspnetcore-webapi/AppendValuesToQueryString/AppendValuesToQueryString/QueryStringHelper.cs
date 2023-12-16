using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Collections.Specialized;
using System.Web;

namespace AppendValuesToQueryString
{
    public static class QueryStringHelper
    {
        private static NameValueCollection ModifyQueryStringUsingParseQueryString(
            string url, Dictionary<string, string> queryParams)
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
            var queryString = ModifyQueryStringUsingParseQueryString(url, queryParams);

            return $"{url.Split('?')[0]}?{queryString}";
        }

        private static Dictionary<string, StringValues> ModifyQueryStringUsingParseQuery(
            string url, Dictionary<string, string> queryParams)
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
            var queryString = ModifyQueryStringUsingParseQuery(url, queryParams);

            return QueryHelpers.AddQueryString(url.Split('?')[0], queryString);
        }

        private static string AppendQueryStringUsingAddQueryString(string url, Dictionary<string, string?> queryParams)
        {
            return QueryHelpers.AddQueryString(url, queryParams);
        }

        public static string CreateURLUsingAddQueryString(string url, Dictionary<string, string?> queryParams)
        {
            return AppendQueryStringUsingAddQueryString(url, queryParams);
        }

        private static string ModifyQueryStringManually(string url, Dictionary<string, string> queryParams)
        {
            var uri = new Uri(url);
            var existingQuery = uri.Query.TrimStart('?');
            var existingParams = existingQuery
                .Split('&')
                .Select(param => param.Split('='))
                .ToDictionary(pair => pair[0], pair => pair.Length > 1 ? pair[1] : null);

            foreach (var kvp in queryParams)
            {
                existingParams[kvp.Key] = kvp.Value;
            }

            var newQuery = string.Join("&", existingParams.
                Select(kvp => kvp.Value != null
                ? $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}" : HttpUtility.UrlEncode(kvp.Key)));

            var newUrl = $"{uri.GetLeftPart(UriPartial.Path)}?{newQuery}{uri.Fragment}";

            return newUrl;
        }

        public static string CreateURL(string url, Dictionary<string, string> queryParams)
        {
            return ModifyQueryStringManually(url, queryParams);
        }
    }
}
