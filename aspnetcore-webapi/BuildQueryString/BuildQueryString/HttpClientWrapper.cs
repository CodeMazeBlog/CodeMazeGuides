namespace BuildQueryString
{
    public class HttpClientWrapper : IHttpClientWrapper
    {
        private static HttpClient _httpClient = new HttpClient();

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return await _httpClient.GetAsync(requestUri);
        }
    }
}
