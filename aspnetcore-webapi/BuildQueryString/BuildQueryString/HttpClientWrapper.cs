namespace BuildQueryString
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private static readonly HttpClient _httpClient = new();

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _httpClient.GetAsync(requestUri);
        }
    }
}
