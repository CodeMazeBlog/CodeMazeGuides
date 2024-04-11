using System.Xml.Serialization;
public static class CarXMLSerializer
{
	public static string SerializeToXmlWithRootName(Car car)
	{
		XmlSerializer serializer = new(typeof(Car), new XmlRootAttribute("MyCar"));
		using StringWriter writer = new();
		serializer.Serialize(writer, car);

		return writer.ToString();
	}
}