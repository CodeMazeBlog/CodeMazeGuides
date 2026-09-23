using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SelectingXmlNodesWithXpath;

public static class XmlNodesSelector
{
    public static string FormatXml(string unformattedXml)
    {
        return XElement.Parse(unformattedXml).ToString();
    }

    public static string? SelectSingleBook(XmlNode root)
    {
        var node = root.SelectSingleNode("//catalog/book[position()=2]");

        return node is null ? null : FormatXml(node.OuterXml);
    }

    public static List<string> SelectBooks(XmlNode root)
    {
        var nodes = root.SelectNodes("//catalog/book[price<50.00]");

        if (nodes is null)
        {
            return [];
        }

        return nodes
            .Cast<XmlNode>()
            .Select(x => FormatXml(x.OuterXml))
            .ToList();
    }

    public static List<string> SelectBooksUsingNamespaces(XmlDocument doc)
    {
        var nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("ex", "urn:example-schema");

        var nodes = doc.SelectNodes("descendant::ex:book", nsmgr);

        if (nodes is null)
        {
            return [];
        }

        return nodes
            .Cast<XmlNode>()
            .Select(x => FormatXml(x.OuterXml))
            .ToList();
    }

    public static List<string> SelectBooksWithLinqToXml(XDocument doc)
    {
        return doc
            .XPathSelectElements("//catalog/book[price<50.00]")
            .Select(x => x.ToString())
            .ToList();
    }
}
