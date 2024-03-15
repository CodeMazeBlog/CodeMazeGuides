using AngleSharp.Html.Parser;
using HtmlAgilityPack;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace RemoveHtmlTagsFromString;

public class HtmlTagRemover
{
    public static string UseRegularExpression(string input)
    {
        var result = Regex.Replace(input, "<.*?>", string.Empty);

        return result;
    }

    public static string UseHtmlDecode(string input)
    {
        var result = UseRegularExpression(input);
        result = WebUtility.HtmlDecode(result);

        return result;
    }

    public static string UseHtmlAgilityPack(string input)
    {
        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(input);

        var result = htmlDoc.DocumentNode.InnerText;
        result = WebUtility.HtmlDecode(result);

        return result;
    }

    public static string UseAngleSharp(string input)
    {
        var parser = new HtmlParser();
        var document = parser.ParseDocument(input);
        var result = document.Body!.TextContent;
        result = WebUtility.HtmlDecode(result);

        return result;
    }

    public static string UseXmlXElement(string input)
    {
        var removedNbspHtml = input.Replace("&nbsp;", " ");
        var xElement = XElement.Parse("<root>" + removedNbspHtml + "</root>");

        return xElement.Value;
    }
}
