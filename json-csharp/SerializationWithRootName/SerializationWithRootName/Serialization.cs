using System.Dynamic;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SerializationWithRootName
{
	public class Serialization
	{
		public static void Main()
		{
			// 1. Use of Wrapper
			SerializeWithWrapper("Rolls Royce", "John");

			// 2. Use of Anonymous Class
			SerializeWithAnonymousClass("Rolls Royce", "John");

			// 3. Use of Custom Serializer
			SerializeWithCustomSerializer("Rolls Royce", "John");

			// 4. Use of DynamicTypes
			SerializeWithDynamicTypes("Rolls Royce", "John");

			// 5. Use of Serializer Settings
			SerializeWithJsonSerializerSettings("Rolls Royce", "John");

			//6. XML serialization
			SerializeToXmlWithRootName("Rolls Royce", "John");
		}

		public static string SerializeWithWrapper(string Model, string Owner)
		{
			var car = new Car { Name = Model, Owner = Owner };

			var wrapper = new { MyCar = car };
			var jsonWrapper = JsonConvert.SerializeObject(wrapper);
			Console.WriteLine(jsonWrapper);

			return jsonWrapper;
		}

		public static string SerializeWithAnonymousClass(string Model, string Owner)
		{
			var carAnonymous = new { MyCar = new { Name = Model, Owner = Owner } };
			string jsonAnonymous = JsonConvert.SerializeObject(carAnonymous);
			Console.WriteLine(jsonAnonymous);

			return jsonAnonymous;
		}

		public static string SerializeWithCustomSerializer(string Model, string Owner)
		{
			var car = new Car { Name = Model, Owner = Owner };

			string jsonCustom = JsonConvert.SerializeObject(car, new CustomJsonConverter());
			Console.WriteLine(jsonCustom);

			return jsonCustom;
		}

		public static string SerializeWithDynamicTypes(string Model, string Owner)
		{
			dynamic carDynamic = new ExpandoObject();
			carDynamic.MyCar = new ExpandoObject();
			carDynamic.MyCar.Name = Model;
			carDynamic.MyCar.Owner = Owner;
			
			string jsonDynamic = JsonConvert.SerializeObject(carDynamic);
			Console.WriteLine(jsonDynamic);

			return jsonDynamic;
		}

		public static string SerializeWithJsonSerializerSettings(string Model, string Owner)
		{
			var car = new Car { Name = Model, Owner = Owner };

			//var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
			var settings = new JsonSerializerSettings
			{
				TypeNameHandling = TypeNameHandling.All,
				Formatting = Formatting.Indented,
			};

			string jsonSettings = JsonConvert.SerializeObject(car, settings);
			Console.WriteLine(jsonSettings);

			return jsonSettings;
		}

		public static string SerializeToXmlWithRootName(string Model, string Owner)
		{
			var car = new Car { Name = Model, Owner = Owner };

			XmlSerializer serializer = new(typeof(Car), new XmlRootAttribute("MyCar"));
			using StringWriter writer = new();
			serializer.Serialize(writer, car);
			Console.WriteLine(writer.ToString());

			return writer.ToString();
		}
	}
}