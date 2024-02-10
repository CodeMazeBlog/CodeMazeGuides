using HTMLContentString;

namespace Tests;

public class HtmlHttpUnitTest
{
    [Fact]
    public async Task WhenGetHtmlAsString_ThenStringResult()
    {
        var url = "https://www.wikipedia.org/";
        var http = new HtmlHttp();

        var html = await http.GetHtmlAsStringAsync(url);
        
        Assert.NotNull(html);
        Assert.IsType<string>(html);
    }
}