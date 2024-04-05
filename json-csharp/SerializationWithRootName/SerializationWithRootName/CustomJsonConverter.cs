using Newtonsoft.Json;

namespace SerializationWithRootName
{
	public class CustomJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var car = (Car)value;

			writer.WriteStartObject();
			writer.WritePropertyName("MyCar");
			writer.WriteStartObject();
			writer.WritePropertyName("name");
			writer.WriteValue(car.Name);
			writer.WritePropertyName("owner");
			writer.WriteValue(car.Owner);
			writer.WriteEndObject();
			writer.WriteEndObject();
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			return null;
		}

		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Car);
		}
	}
}