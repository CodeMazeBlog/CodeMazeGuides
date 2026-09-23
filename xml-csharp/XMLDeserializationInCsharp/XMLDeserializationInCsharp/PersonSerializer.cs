using System.Xml.Serialization;

namespace XMLDeserializationInCsharp;

public static class PersonSerializer
{
    private static readonly XmlSerializer _serializer =
        new(typeof(Person), new XmlRootAttribute("Contact"));

    public static Person? Deserialize(string xml)
    {
        using var reader = new StringReader(xml);

        return (Person?)_serializer.Deserialize(reader);
    }
}
