using System.Xml;
using System.Xml.Serialization;

namespace XMLDeserializationInCsharp
{
	public record BookRecord([property: XmlElement("Title")] string Title, [property: XmlElement("Author")] string Author)
	{
		private BookRecord() : this("", "")
		{

		}
	}
}