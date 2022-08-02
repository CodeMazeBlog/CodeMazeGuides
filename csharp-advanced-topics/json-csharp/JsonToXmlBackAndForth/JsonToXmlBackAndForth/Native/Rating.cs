using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace JsonToXmlBackAndForth.Native;

public class Rating
{
    [XmlAttribute]
    [JsonPropertyName("@Type")]
    public string? Type { get; set; }
    [XmlText]
    [JsonPropertyName("#text")]
    public string? Text { get; set; }
}
