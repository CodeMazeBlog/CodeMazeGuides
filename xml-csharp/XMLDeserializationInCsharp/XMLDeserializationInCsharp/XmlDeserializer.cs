using System.Xml.Serialization;

namespace XMLDeserializationInCsharp;

public static class XmlDeserializer
{
    public static T? DeserializeXmlData<T>(string xmlData)
    {
        var serializer = new XmlSerializer(typeof(T));
        using var reader = new StringReader(xmlData);

        return (T?)serializer.Deserialize(reader);
    }
}
