namespace HTMLContentString;

public class HtmlHttp
{
    private readonly HttpClient _httpClient;

    public HtmlHttp(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }

    public async Task<string> GetHtmlAsStringAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();

        var htmlContent = await response.Content.ReadAsStringAsync();
        
        return htmlContent;
    }
}