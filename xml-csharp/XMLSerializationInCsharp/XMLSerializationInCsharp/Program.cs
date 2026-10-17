using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using XMLSerializationInCsharp_v1;

var patient = new Patient()
{
    ID = 232323,
    FirstName = "John",
    LastName = "Doe",
    Birthday = new DateTime(1990, 12, 30),
    RoomNo = 310
};

// The article's first example: a StreamWriter over a file.
var serializer = new XmlSerializer(typeof(Patient));
using (var writer = new StreamWriter("patients.xml"))
{
    serializer.Serialize(writer, patient);
}

Console.WriteLine(File.ReadAllText("patients.xml"));
Console.WriteLine();

// The article's last example: an XmlWriter with indentation, UTF-8 without a byte order mark,
// and no xmlns:xsi or xmlns:xsd declarations on the root element.
var namespaces = new XmlSerializerNamespaces();
namespaces.Add(string.Empty, string.Empty);

var settings = new XmlWriterSettings
{
    Indent = true,
    Encoding = new UTF8Encoding(false)
};

using (var xmlWriter = XmlWriter.Create("patient.xml", settings))
{
    serializer.Serialize(xmlWriter, patient, namespaces);
}

Console.WriteLine(File.ReadAllText("patient.xml"));
