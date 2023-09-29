using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System.Web;

namespace BuildQueryString
{
    public class QueryStringService
    {
        const string BaseApiUrl = "https://localhost:7220/api/Books";
        private readonly IHttpClientWrapper _httpClientWrapper;

        public QueryStringService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<string> BuildQueryStringUsingStringConcat(string author, string language)
        {
            var queryString = "?author=" + author + "&language=" + language;

            string fullApiUrl = BaseApiUrl + queryString;
            Console.Write($"Full API Url: {fullApiUrl}");

            await CallBooksApi(fullApiUrl);

            return fullApiUrl;
        }

        public async Task<string> BuildQueryStringByEncoding(string author, string language)
        {
            var queryString = "?author=" + HttpUtility.UrlEncode(author) + "&language=" + language;

            string fullApiUrl = BaseApiUrl + queryString;
            Console.Write($"Full API Url: {fullApiUrl}");

            await CallBooksApi(fullApiUrl);

            return fullApiUrl;
        }

        public async Task<string> BuildQueryStringUsingUriBuilder(string author, string language)
        {
            UriBuilder uriBuilder = new UriBuilder("https://localhost:7220");

            uriBuilder.Path = "/api/Books";
            uriBuilder.Query = "author=" + author + "&language=" + language;

            Uri fullApiUrl = uriBuilder.Uri;
            Console.Write($"Full API Url: {fullApiUrl}");

            await CallBooksApi(fullApiUrl.ToString());

            return fullApiUrl.ToString();
        }

        public async Task<string> BuildQueryStringUsingParseQueryStringMethod(string author, string language)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            query["author"] = author;
            query["language"] = language;

            string fullApiUrl = BaseApiUrl + "?" + query.ToString();
            Console.Write($"Full API Url: {fullApiUrl}");

            await CallBooksApi(fullApiUrl);

            return fullApiUrl;
        }

        public async Task<string> BuildQueryStringUsingAddQueryStringMethod(string author, string language)
        {
            var queryParams = new Dictionary<string, string> { { "author", author }, { "language", language } };

            string fullApiUrl = QueryHelpers.AddQueryString(BaseApiUrl, queryParams);
            Console.Write($"Full API Url: {fullApiUrl}");

            await CallBooksApi(fullApiUrl);

            return fullApiUrl;
        }

        public async Task<string> BuildQueryStringUsingQueryBuilderClass(string author, string language)
        {
            var queryParams = new Dictionary<string, string> { { "author", author }, { "language", language } };

            var queryBuilder = new QueryBuilder(queryParams);

            string fullApiUrl = BaseApiUrl + queryBuilder;
            Console.Write($"Full API Url: {fullApiUrl}");

            await CallBooksApi(fullApiUrl);

            return fullApiUrl;
        }

        public async Task<string> BuildQueryStringUsingCreateMethod(string author, string language)
        {
            var queryParams = new Dictionary<string, string> { { "author", author }, { "language", language } };

            var queryString = QueryString.Create(queryParams);

            string fullApiUrl = BaseApiUrl + queryString;
            Console.Write($"Full API Url: {fullApiUrl}");

            await CallBooksApi(fullApiUrl);

            return fullApiUrl;
        }

        public async Task CallBooksApi(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClientWrapper.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("\n");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"HTTP Error: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
