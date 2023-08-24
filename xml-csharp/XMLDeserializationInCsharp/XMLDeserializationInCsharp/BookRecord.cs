using System.Xml;
using System.Xml.Serialization;

public record BookRecord([property: XmlElement("Title")] string Title, [property: XmlElement("Author")] string Author)
{
    private BookRecord() : this("", "")
    {

    }
}