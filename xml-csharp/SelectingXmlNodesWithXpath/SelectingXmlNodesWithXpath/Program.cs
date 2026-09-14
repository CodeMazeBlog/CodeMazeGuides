using SelectingXmlNodesWithXpath;
using System.Xml;
using System.Xml.Linq;

var path = Path.Combine(AppContext.BaseDirectory, "BooksCatalog.xml");

var doc = new XmlDocument();
doc.Load(path);
var root = doc.DocumentElement!;

Console.WriteLine("Selected book:");
var singleResult = XmlNodesSelector.SelectSingleBook(root);
Console.WriteLine(singleResult ?? "No book matched the query.");

Console.WriteLine("\nSelected books:");
var results = XmlNodesSelector.SelectBooks(root);
results.ForEach(Console.WriteLine);

Console.WriteLine("\nSelected books:");
var resultsFromNamespaces = XmlNodesSelector.SelectBooksUsingNamespaces(doc);
resultsFromNamespaces.ForEach(Console.WriteLine);

Console.WriteLine("\nSelected books with LINQ to XML:");
var linqResults = XmlNodesSelector.SelectBooksWithLinqToXml(XDocument.Load(path));
linqResults.ForEach(Console.WriteLine);
