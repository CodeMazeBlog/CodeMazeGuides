namespace BuildQueryString
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            using HttpClient _httpClient = new();

            return await _httpClient.GetAsync(requestUri);
        }
    }
}
