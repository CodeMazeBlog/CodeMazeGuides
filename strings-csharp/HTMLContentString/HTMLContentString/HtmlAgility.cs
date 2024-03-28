using HtmlAgilityPack;

namespace HTMLContentString;

public class HtmlAgility
{
    public string GetHtmlAsString(string url)
    {
        var web = new HtmlWeb();
        var doc = web.Load(url);
        
        return doc.DocumentNode.OuterHtml;
    }
    
    public List<string> GetList(string htmlContent)
    {
        var doc = new HtmlDocument();
        doc.LoadHtml(htmlContent);

        var nodes = doc.DocumentNode.SelectNodes("//ul[@class='list']/li");
        var result = new List<string>();

        if (nodes != null)
        {
            foreach (var node in nodes)
            {
                result.Add(node.InnerText);
            }
        }

        return result;
    }
}