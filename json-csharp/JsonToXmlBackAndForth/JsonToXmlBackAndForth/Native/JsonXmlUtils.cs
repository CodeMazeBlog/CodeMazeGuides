using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace JsonToXmlBackAndForth.Native;

public static class JsonXmlUtils
{
    public static string JsonToXml(string json)
    {
        var obj = JsonSerializer.Deserialize<RootObject>(json)!;

        return ObjectToXml(obj.SquidGame);
    }

    static string ObjectToXml<T>(T obj)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        var sb = new StringBuilder();
        using var xmlWriter = XmlWriter.Create(sb);

        var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        xmlSerializer.Serialize(xmlWriter, obj, ns);

        return sb.ToString();
    }

    public static string XmlToJson(string xml)
    {
        var obj = XmlToObject<SquidGame>(xml);

        return JsonSerializer.Serialize(new RootObject { SquidGame = obj });
    }

    static T XmlToObject<T>(string xml)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        using var stringReader = new StringReader(xml);
        
        return (T)xmlSerializer.Deserialize(stringReader)!;
    }
}