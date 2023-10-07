namespace BuildQueryString
{
    public class BooksApiService
    {
        private const string BaseApiUrl = "https://localhost:7220/api/Books";
        private readonly IHttpClientWrapper _httpClientWrapper;

        public BooksApiService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<string> HttpGetAsync(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _httpClientWrapper.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return string.Empty;
            }

        }

        public async Task<string> GetWithQueryParamsUsingStringConcatenation(string author, string language)
        {
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };

            return await HttpGetAsync(QueryStringHelper.BuildUrlWithQueryStringUsingStringConcat(BaseApiUrl, dict));
        }

        public async Task<string> GetWithQueryParamsUsingStringConcatenationByEncoding(string author, string language)
        {
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };

            return await HttpGetAsync(QueryStringHelper.BuildUrlWithQueryStringUsingStringConcatByEncoding(BaseApiUrl, dict));
        }

        public async Task<string> GetWithQueryParamsUsingUriBuilder(string author, string language)
        {
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };

            return await HttpGetAsync(QueryStringHelper.BuildUrlWithQueryStringUsingUriBuilder(BaseApiUrl, dict));
        }

        public async Task<string> GetWithQueryParamsUsingParseQueryStringMethod(string author, string language)
        {
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };

            return await HttpGetAsync(QueryStringHelper.BuildUrlWithQueryStringUsingParseQueryStringMethod(BaseApiUrl, dict));
        }

        public async Task<string> GetWithQueryParamsUsingAddQueryStringMethod(string author, string language)
        {
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };

            return await HttpGetAsync(QueryStringHelper.BuildUrlWithQueryStringUsingAddQueryStringMethod(BaseApiUrl, dict));
        }

        public async Task<string> GetWithQueryParamsUsingQueryBuilderClass(string author, string language)
        {
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };

            return await HttpGetAsync(QueryStringHelper.BuildUrlWithQueryStringUsingQueryBuilderClass(BaseApiUrl, dict));
        }

        public async Task<string> GetWithQueryParamsUsingCreateMethod(string author, string language)
        {
            var dict = new Dictionary<string, string>
            {
                { "author", author },
                { "language", language }
            };

            return await HttpGetAsync(QueryStringHelper.BuildurlWithQueryStringUsingCreateMethod(BaseApiUrl, dict));
        }
    }
}
