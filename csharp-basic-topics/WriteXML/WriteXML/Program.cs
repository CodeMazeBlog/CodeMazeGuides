using System.Reflection;
using WriteXML;
using WriteXML.Create;

var people = People.Get(5);

var usingLinq = new CreateXMLUsingLinq();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateSimpleXML(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateSimpleXMLWithAttributes(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateXMLWithNamespace(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateXMLWithNamespace2(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this data.\n");
Persons2String(people)
    .ToList()
    .ForEach(Console.WriteLine);
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateAnArrayOfPeople(people));
Console.ReadKey();

var usingXmlWriter = new CreateXMLUsingXmlWriter();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateSimpleXML(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateSimpleXMLWithAttributes(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateXMLWithNamespace(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateXMLWithNamespace2(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this data.\n");
Persons2String(people)
    .ToList()
    .ForEach(Console.WriteLine);
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateAnArrayOfPeople(people));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlReader: Convert CVS into XML:\n");
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var csvFile = Path.Combine(currentFolder!, "resources", "teams.csv");
var csvLines = File.ReadAllLines(csvFile);
var converter = new ConvertCvs2Xml(csvLines, false, "teams", "team");
var document1 = converter.Convert();
Console.WriteLine("\n---\n");
Console.WriteLine(document1.ToString());
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlReader: Convert CVS into XML:\n");
csvFile = Path.Combine(currentFolder!, "resources", "names.csv");
csvLines = File.ReadAllLines(csvFile);
converter = new ConvertCvs2Xml(csvLines, true, "people", "person");
var document2 = converter.Convert();
Console.WriteLine("\n---\n");
Console.WriteLine(document2.ToString());
Console.ReadKey();

string Person2String(Person person)
{
    return $"Person: {person.FirstName} {person.LastName}, {person.Email}, {person.Age}";
}

string[] Persons2String(Person[] persons)
{
    return persons.Select(p => Person2String(p)).ToArray();
}