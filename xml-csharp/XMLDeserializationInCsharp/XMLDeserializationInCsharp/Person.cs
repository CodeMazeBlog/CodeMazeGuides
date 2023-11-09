using System.Xml.Serialization;

namespace XMLDeserializationInCsharp
{
	[XmlRoot("Person")]
	public class Person
	{
		[XmlElement("Name")]
		public string Name { get; set; } = string.Empty;
		[XmlElement("Age")]
		public int Age { get; set; } = int.MinValue;
	}
}
