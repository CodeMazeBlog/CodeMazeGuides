using ReadXml;
using ReadXml.Read;
using System.Reflection;

var people = People.Get(5);

Console.Clear();
Console.WriteLine("XDocument: Read valid XML Document.\n");
var xmlString = ReadXmlUsingXDocument.TestValidXml();
Console.WriteLine("\n---\n");
Console.WriteLine(xmlString);
Console.ReadKey();

Console.Clear();
Console.WriteLine("XDocument: Read invalid XML Document.\n");
xmlString = ReadXmlUsingXDocument.TestInvalidXml();
Console.WriteLine("\n---\n");
Console.WriteLine(xmlString);
Console.ReadKey();

Console.Clear();
Console.WriteLine("XDocument: Read elements using Element collection.\n");
Console.WriteLine("\n---\n");
xmlString = ReadXmlUsingXDocument.TestReadWithElementCollection();
Console.WriteLine(xmlString);
Console.ReadKey();

Console.Clear();
Console.WriteLine("XDocument: Read elements using XPath.\n");
Console.WriteLine("\n---\n");
xmlString = ReadXmlUsingXDocument.TestReadUsingXPath();
Console.WriteLine(xmlString);
Console.ReadKey();

var sampleXML = CreateXmlUsingXmlWriter.CreateSimpleXml(people[0]);

Console.Clear();
Console.WriteLine("XmlReader: Read all elements:\n");
Console.WriteLine("\n---\n");
ReadXmlUsingXmlReader.ReadXml(sampleXML)
    .ToList()
    .ForEach(Console.WriteLine);
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlReader: Read elements except whitespaces:\n");
Console.WriteLine("\n---\n");
ReadXmlUsingXmlReader.ReadXmlWithoutWhiteSpace(sampleXML)
    .ToList()
    .ForEach(Console.WriteLine);
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlReader: Read names and surnames from XML document with people data:\n");
Console.WriteLine("\n---\n");
ReadXmlUsingXmlReader.ReadNamesAndSurnames(
    CreateXmlUsingXmlWriter.CreateAnArrayOfPeople(people)
    )
    .ToList()
    .ForEach(Console.WriteLine);
Console.ReadKey();

Console.Clear();
Console.WriteLine("Read an XML file from the output folder:\n");
Console.WriteLine("\n---\n");
ReadXmlFromFile.ReadEmailsUsingXDocument(ReadXmlFromFile.FilePath)
    .ToList()
    .ForEach(Console.WriteLine);
ReadXmlFromFile.ReadEmailsUsingXmlReader(ReadXmlFromFile.FilePath)
    .ToList()
    .ForEach(Console.WriteLine);
ReadXmlUsingXmlDocument.ReadEmails(ReadXmlFromFile.FilePath)
    .ToList()
    .ForEach(Console.WriteLine);
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlReader: Read names and surnames from people.xml:\n");
Console.WriteLine("\n---\n");
var xml = File.ReadAllText(ReadXmlFromFile.FilePath);

foreach (var row in ReadXmlUsingXmlReader.ReadNamesAndSurnames(xml))
    Console.WriteLine(row);
