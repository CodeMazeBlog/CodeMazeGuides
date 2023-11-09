using System.Xml.Serialization;

namespace XMLDeserializationInCsharp
{
	public class Book
	{
		[XmlElement("Title")]
		public string Title { get; set; } = string.Empty;

		[XmlElement("Author")]
		public string Author { get; set; } = string.Empty;
	}
}
