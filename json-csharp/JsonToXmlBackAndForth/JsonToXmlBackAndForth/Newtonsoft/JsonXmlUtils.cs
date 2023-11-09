using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;
using Formatting = Newtonsoft.Json.Formatting;

namespace JsonToXmlBackAndForth.Newtonsoft;

public static class JsonXmlUtils
{
    #region XML to JSON
    public static string XmlToJson(string xml)
    {
        var doc = XDocument.Parse(xml);

        return JsonConvert.SerializeXNode(doc);
    }

    public static string XmlDocumentToJson(string xml)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xml);

        return JsonConvert.SerializeXmlNode(doc);
    }

    public static string XmlToPrettyJson(string xml)
    {
        var doc = XDocument.Parse(xml);

        return JsonConvert.SerializeXNode(doc, Formatting.Indented);
    }

    public static string XmlToJsonWithJsonArrayFlag(string xml)
    {
        var doc = XDocument.Parse(xml);

        if (doc.Root!.Elements("Stars") is { } elements && elements.Count() == 1)
        {
            var jsonNamespace = "http://james.newtonking.com/projects/json";
            doc.Root!.Add(new XAttribute(XNamespace.Xmlns + "json", jsonNamespace));

            elements.Single().Add(new XAttribute(XNamespace.Get(jsonNamespace) + "Array", true));
        }

        return JsonConvert.SerializeXNode(doc);
    }

    public static string XmlToJsonWithoutRoot(string xml)
    {
        var doc = XDocument.Parse(xml);

        return JsonConvert.SerializeXNode(doc, Formatting.None, omitRootObject: true);
    }
    #endregion

    #region JSON to XML
    private static readonly XDeclaration _defaultDeclaration = new("1.0", null, null);

    public static string JsonToXml(string json)
    {
        var doc = JsonConvert.DeserializeXNode(json)!;

        var declaration = doc.Declaration ?? _defaultDeclaration;

        return $"{declaration}{Environment.NewLine}{doc}";
    }

    public static string JsonToXmlWithExplicitRoot(string json, string rootName)
    {
        var doc = JsonConvert.DeserializeXNode(json, rootName)!;

        var declaration = doc.Declaration ?? _defaultDeclaration;

        return $"{declaration}{Environment.NewLine}{doc}";
    }
    #endregion
}