using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SerializationWithRootName;
using System.Xml;
using System.Xml.Serialization;

public class Serialization
{

	public static string SerializeToJsonWithRootName(List<Car> car)
	{
		return JsonConvert.SerializeObject(new { car });
	}


	public static string SerializeToXmlWithRootName(List<Car> cars)
	{
		XmlSerializer serializer = new(typeof(List<Car>), new XmlRootAttribute("Cars"));
		using StringWriter writer = new();
		serializer.Serialize(writer, cars);
		return writer.ToString();
	}
}
