using System.Xml.Serialization;

namespace JsonToXmlBackAndForth.Native;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
public class SquidGame
{
    public string Genre { get; set; }
    public Rating Rating { get; set; }
    [XmlElement]
    public string[] Stars { get; set; }
    public object Budget { get; set; }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.