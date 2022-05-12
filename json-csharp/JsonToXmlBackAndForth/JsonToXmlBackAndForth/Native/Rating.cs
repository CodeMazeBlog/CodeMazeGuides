using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace JsonToXmlBackAndForth.Native;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class Rating
{
    [XmlAttribute]
    [JsonPropertyName("@Type")]
    public string Type { get; set; }
    [XmlText]
    [JsonPropertyName("#text")]
    public string Text { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.