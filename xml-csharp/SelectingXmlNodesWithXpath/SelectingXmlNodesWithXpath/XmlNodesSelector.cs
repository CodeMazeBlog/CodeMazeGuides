using System.Xml;

namespace SelectingXmlNodesWithXpath;

internal static class XmlNodesSelector
{
    public static void SelectSingleBook(XmlNode root)
    {
        var node = root.SelectSingleNode("//catalog/book[position()=2]");
        if (node != null)
        {
            Console.WriteLine($"Book: {node.OuterXml}");
        }
    }

    public static void SelectBooks(XmlNode root)
    {
        var nodes = root.SelectNodes("//catalog/book[price<50.00]");
        if (nodes?.Count > 0)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine($"Book: {nodes[i]?.OuterXml}");
            }
        }
    }

    public static void SelectBooksUsingNamespaces(XmlDocument doc)
    {
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("ex", "urn:example-schema");

        var nodes = doc.SelectNodes("descendant::ex:book", nsmgr);
        if (nodes?.Count > 0)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Console.WriteLine($"Book: {nodes[i]?.OuterXml}");
            }
        }
    }
}
