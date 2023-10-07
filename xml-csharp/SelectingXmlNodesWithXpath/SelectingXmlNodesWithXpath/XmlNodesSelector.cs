using System.Xml;
using System.Xml.Linq;

namespace SelectingXmlNodesWithXpath;

public static class XmlNodesSelector
{
    public static string FormatXml(string unformattedXml)
    {
        return XElement.Parse(unformattedXml).ToString();
    }

    public static string SelectSingleBook(XmlNode root)
    {
        var node = root.SelectSingleNode("//catalog/book[position()=2]");
        
        return FormatXml(node!.OuterXml);
    }

    public static List<string> SelectBooks(XmlNode root)
    {
        var nodes = root.SelectNodes("//catalog/book[price<50.00]");

        return nodes!
            .Cast<XmlNode>()
            .Select(x => FormatXml(x.OuterXml))
            .ToList();
    }

    public static List<string> SelectBooksUsingNamespaces(XmlDocument doc)
    {
        var nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("ex", "urn:example-schema");

        var nodes = doc.SelectNodes("descendant::ex:book", nsmgr);

        return nodes!
            .Cast<XmlNode>()
            .Select(x => FormatXml(x.OuterXml))
            .ToList();
    }
}
