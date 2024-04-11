using Newtonsoft.Json;

public class CarJsonConverter : JsonConverter
{
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		var car = (Car)value;

		writer.WriteStartObject();
		writer.WritePropertyName("MyCar");
		writer.WriteStartObject();
		writer.WritePropertyName("Make");
		writer.WriteValue(car.Make);
		writer.WritePropertyName("Model");
		writer.WriteValue(car.Model);
		writer.WritePropertyName("Year");
		writer.WriteValue(car.Year);
		writer.WriteEndObject();
		writer.WriteEndObject();
	}

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		var make = string.Empty;
		var model = string.Empty;
		int year = 0;
		if (reader.TokenType == JsonToken.StartObject)
		{
			while (reader.Read())
			{
				if (reader.TokenType == JsonToken.PropertyName)
				{
					var propertyName = reader.Value.ToString();
					switch (propertyName)
					{
						case "make":
							reader.Read();
							make = reader.Value.ToString();
							break;
						case "model":
							reader.Read();
							model = reader.Value.ToString();
							break;
						case "year":
							reader.Read();
							year = Convert.ToInt16(reader.Value);
							break;
					}
				}
				else if (reader.TokenType == JsonToken.EndObject)
				{
					break;
				}
			}
		}
		return new Car { Make = make, Model = model, Year = year };
	}

	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(Car);
	}
}