using AngleSharp.Common;
using RemoveHtmlTagsFromString;
using System.Text;
using System.Net;

namespace RemoveHtmlTagsTests;

[TestClass]
public class HtmlTagRemoverTests
{
    private IFixture? _fixture;

    [TestInitialize]
    public void Setup()
    {
        _fixture = new Fixture();
    }

    [TestMethod]
    public void WhenUseRegularExpressionCalled_ThenHtmlTagsRemovedButEncodedValuesRemain()
    {
        var parameters = GenerateHtml();

        var result = HtmlTagRemover.UseRegularExpression(parameters.Item2);
        var expected = parameters.Item3;

        Assert.AreEqual(ToUtf8(expected), ToUtf8(result));
    }

    [TestMethod]
    public void WhenUseUseHtmlDecodeCalled_ThenHtmlTagsAndEncodedValuesRemoved()
    {
        var parameters = GenerateHtml();

        var result = HtmlTagRemover.UseHtmlDecode(parameters.Item2);
        var expected = parameters.Item1;

        Assert.AreEqual(ToUtf8(expected), ToUtf8(result));
    }

    [TestMethod]
    public void WhenUseHtmlAgilityPackCalled_ThenHtmlTagsAndEncodedValuesRemoved()
    {
        var parameters = GenerateHtml();

        var result = HtmlTagRemover.UseHtmlAgilityPack(parameters.Item2);
        var expected = parameters.Item1;

        Assert.AreEqual(ToUtf8(expected), ToUtf8(result));
    }

    [TestMethod]
    public void WhenUseAngleSharpCalled_ThenHtmlTagsAndEncodedValuesRemoved()
    {
        var parameters = GenerateHtml();

        var result = HtmlTagRemover.UseAngleSharp(parameters.Item2);
        var expected = parameters.Item1;

        Assert.AreEqual(ToUtf8(expected), ToUtf8(result));
    }

    [TestMethod]
    public void WhenUseXmlXElementCalled_ThenHtmlTagsAndEncodedValuesRemoved()
    {
        var parameters = GenerateHtml();

        var result = HtmlTagRemover.UseXmlXElement(parameters.Item2);
        var expected = parameters.Item1;

        Assert.AreEqual(ToUtf8(expected), ToUtf8(result));
    }

    private Tuple<string, string, string> GenerateHtml()
    {
        var tagList = new List<string>() { "p", "a", "b", "div", "ul", "li", "table", "style", "span" };
        var encodedList = new List<string> { "&nbsp;", "&gt;", "&lt;", "&amp;" };

        var saltText = string.Empty;
        var htmlText = string.Empty;
        var saltTextEncoded = string.Empty;

        var content = _fixture.Create<string>();
        var tag = tagList[new Random().Next(0, tagList.Count)];
        var encodedKey = encodedList.GetItemByIndex(new Random().Next(0, encodedList.Count));

        saltText += content + encodedKey;
        saltTextEncoded += content + encodedKey;
        htmlText += string.Format("<{0}>{1}{2}</{0}>", tag, content, encodedKey);

        content = _fixture.Create<string>();
        tag = tagList[new Random().Next(0, tagList.Count)];
        encodedKey = encodedList.GetItemByIndex(new Random().Next(0, encodedList.Count));

        saltText += content + encodedKey;
        saltTextEncoded += content + encodedKey;
        htmlText += string.Format("<{0}>{1}{2}</{0}>", tag, content, encodedKey);

        content = _fixture.Create<string>();
        tag = tagList[new Random().Next(0, tagList.Count)];
        encodedKey = encodedList.GetItemByIndex(new Random().Next(0, encodedList.Count));

        saltText += content + encodedKey;
        saltTextEncoded += content + encodedKey;
        htmlText += string.Format("<{0}>{1}{2}</{0}>", tag, content, encodedKey);
        saltText = WebUtility.HtmlDecode(saltText).Trim().Replace(" ", " ");

        return new Tuple<string, string, string>(saltText, htmlText.Trim(), saltTextEncoded.Trim());
    }

    private static string ToUtf8(string value)
    {
        if (!string.IsNullOrEmpty(value))
        {
            return Encoding.UTF8.GetString(Encoding.Default.GetBytes(value.Trim())).Replace(" ", " ");
        }

        return value;
    }
}