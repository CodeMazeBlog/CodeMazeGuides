using System.Reflection;
using WriteXML;
using WriteXML.Create;

var people = People.Get(5);

var usingLinq = new CreateXmlUsingLinq();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateSimpleXml(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateSimpleXmlWithAttributes(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateXmlWithNamespace(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateXmlWithThreeNamespaces(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Display XML with declaration.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(CreateXmlUsingLinq.CreateSimpleXmlWithXmlDeclaration(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("Linq To XML: Create XML using array of people.\n");
Persons2String(people)
    .ToList()
    .ForEach(Console.WriteLine);
Console.WriteLine("\n---\n");
Console.WriteLine(usingLinq.CreateAnArrayOfPeople(people));
Console.ReadKey();


var usingXmlWriter = new CreateXmlUsingXmlWriter();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateSimpleXml(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateSimpleXmlWithAttributes(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateXmlWithNamespace(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using this person data.\n");
Console.WriteLine(Person2String(people[0]));
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateXmlWithThreeNamespaces(people[0]));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlWriter: Create XML using array of people.\n");
Persons2String(people)
    .ToList()
    .ForEach(Console.WriteLine);
Console.WriteLine("\n---\n");
Console.WriteLine(usingXmlWriter.CreateAnArrayOfPeople(people));
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlReader: Convert CSV into XML:\n");
var currentFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
var csvFile = Path.Combine(currentFolder!, "resources", "teams.csv");
var csvLines = File.ReadAllLines(csvFile);
var converter = new ConvertCsv2Xml(csvLines, false, "teams", "team");
var document1 = converter.Convert();
Console.WriteLine("\n---\n");
Console.WriteLine(document1.ToString());
Console.ReadKey();

Console.Clear();
Console.WriteLine("XmlReader: Convert CSV into XML:\n");
csvFile = Path.Combine(currentFolder!, "resources", "names.csv");
csvLines = File.ReadAllLines(csvFile);
converter = new ConvertCsv2Xml(csvLines, true, "people", "person");
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