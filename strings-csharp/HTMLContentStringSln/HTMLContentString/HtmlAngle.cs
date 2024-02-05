using AngleSharp;
using AngleSharp.Html.Parser;

namespace HTMLContentString;

public class HtmlAngle
{
    public async Task<string> GetHtmlAsStringAsync(string url)
    {
        var config = Configuration.Default.WithDefaultLoader();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync(url);

        return document.Body.InnerHtml;
    }
    public List<string> GetList(string htmlContent)
    {
        var parser = new HtmlParser();
        var document = parser.ParseDocument(htmlContent);

        var nodes = document.QuerySelectorAll("ul.list > li");
        var result = new List<string>();

        foreach (var node in nodes)
        {
            result.Add(node.TextContent);
        }

        return result;
    }
}