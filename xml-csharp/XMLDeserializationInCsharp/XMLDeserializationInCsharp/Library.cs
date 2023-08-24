using System.Xml.Serialization;

namespace XMLDeserializationInCsharp
{
    [XmlRoot("Library")]
    public class Library
    {
        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<Book> Books { get; set; } = new();
    }
}
