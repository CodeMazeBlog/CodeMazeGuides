using SelectingXmlNodesWithXpath;
using System.Xml;

var doc = new XmlDocument();
doc.Load("BooksCatalog.xml");
var root = doc.DocumentElement!;

Console.WriteLine("Selected book:");
var singleResult = XmlNodesSelector.SelectSingleBook(root);
Console.WriteLine(singleResult);

Console.WriteLine("\nSelected books:");
var results = XmlNodesSelector.SelectBooks(root);
results.ForEach(Console.WriteLine);

Console.WriteLine("\nSelected books:");
var resultsFromNamespaces = XmlNodesSelector.SelectBooksUsingNamespaces(doc);
resultsFromNamespaces.ForEach(Console.WriteLine);