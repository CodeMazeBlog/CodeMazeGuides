using System.Xml.Serialization;

namespace JsonToXmlBackAndForth.Native;

public class SquidGame
{
    public string? Genre { get; set; }
    public Rating? Rating { get; set; }
    [XmlElement]
    public string[]? Stars { get; set; }
    public object? Budget { get; set; }
}
