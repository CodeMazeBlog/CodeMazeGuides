using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using System.Collections.Specialized;
using System.Web;

namespace AppendValuesToQueryString
{
    public static class QueryStringHelper
    {
        private static (NameValueCollection query, string fragment) ModifyQueryStringUsingParseQueryString(
            string url, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(url);

            var query = HttpUtility.ParseQueryString(uriBuilder.Query);

            foreach (var kvp in queryParams)
            {
                query.Set(HttpUtility.UrlEncode(kvp.Key), kvp.Value);
            }

            return (query, uriBuilder.Fragment);
        }

        public static string CreateURLUsingParseQueryString(string url, Dictionary<string, string> queryParams)
        {
            var result = ModifyQueryStringUsingParseQueryString(url, queryParams);

            return $"{url.Split('?')[0]}?{result.query}{result.fragment}";
        }

        private static (Dictionary<string, StringValues> query, string fragment) ModifyQueryStringUsingParseQuery(
            string url, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(url);

            var query = QueryHelpers.ParseQuery(uriBuilder.Query);

            foreach (var kvp in queryParams)
            {
                query[kvp.Key] = kvp.Value;
            }

            return (query, uriBuilder.Fragment);
        }

        public static string CreateURLUsingParseQuery(string url, Dictionary<string, string> queryParams)
        {
            var result = ModifyQueryStringUsingParseQuery(url, queryParams);

            return QueryHelpers.AddQueryString(url.Split('?')[0], result.query) + result.fragment;
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
