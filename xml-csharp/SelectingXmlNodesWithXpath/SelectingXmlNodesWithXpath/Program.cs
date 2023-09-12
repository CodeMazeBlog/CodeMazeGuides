using System.Xml;

namespace SelectingXmlNodesWithXpath
{
    internal class Program
    {
        static void SelectSingleBook(XmlNode root)
        {
            var node = root.SelectSingleNode("//catalog/book[position()=2]");
            if (node != null)
            {
                Console.WriteLine($"Book: {node.OuterXml}");
            }
        }

        static void SelectBooks(XmlNode root)
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

        static void SelectBooksUsingNamespaces(XmlDocument doc)
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

        static void Main(string[] args)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load("BooksCatalog.xml");
                var root = doc.DocumentElement;

                Console.WriteLine("Let's select a single book:");
                SelectSingleBook(root);

                Console.WriteLine("\nLet's select a few books:");
                SelectBooks(root);

                Console.WriteLine("\nLet's select a single book using XML namespaces:");
                SelectBooksUsingNamespaces(doc);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}