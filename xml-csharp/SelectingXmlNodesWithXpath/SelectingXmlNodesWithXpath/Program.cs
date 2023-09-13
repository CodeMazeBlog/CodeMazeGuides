using System.Xml;

namespace SelectingXmlNodesWithXpath;

internal class Program
{
    static void Main(string[] args)
    {
        var doc = new XmlDocument();
        doc.Load("BooksCatalog.xml");
        var root = doc.DocumentElement;

        Console.WriteLine("Let's select a single book:");
        XmlNodesSelector.SelectSingleBook(root);

        Console.WriteLine("\nLet's select a few books:");
        XmlNodesSelector.SelectBooks(root);

        Console.WriteLine("\nLet's select a single book using XML namespaces:");
        XmlNodesSelector.SelectBooksUsingNamespaces(doc);
    }
}