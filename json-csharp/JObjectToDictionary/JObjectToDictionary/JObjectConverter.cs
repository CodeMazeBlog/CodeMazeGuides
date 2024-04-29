using Newtonsoft.Json.Linq;


namespace JObjectToDictionary
{
    public static class JObjectConverter
    {
        public static Dictionary<string, object> ConvertJObjectToDictionary(JObject jsonObject)
        {
            Dictionary<string, object> result = new();

            foreach (var property in jsonObject.Properties())
            {
                string key = property.Name;
                JToken value = property.Value;

                switch (value.Type)
                {
                    case JTokenType.Object:
                        if (value is JObject nestedObject)
                        {
                            result[key] = ConvertJObjectToDictionary(nestedObject);
                        }
                        break;
                    case JTokenType.Array:
                        if(value is JArray array)
                        {
                            result[key] = ConvertJArrayToList(array);
                        }
                        break;
                    default:
                        result[key] = ((JValue)value).Value!;
                        break;
                }
            }

            return result;
        }

        private static List<object> ConvertJArrayToList(JArray jArray)
        {
            var result = new List<object>();

            foreach (var item in jArray)
            {
                switch (item.Type)
                {
                    case JTokenType.Object:
                        if (item is JObject nestedObject)
                        {
                            result.Add(ConvertJObjectToDictionary(nestedObject));
                        }
                        break;
                    case JTokenType.Array:
                        if (item is JArray array)
                        {
                            result.Add(ConvertJArrayToList(array));
                        }
                        break;
                    default:
                        result.Add(((JValue)item).Value!);
                        break;
                }
            }

            return result;
        }

        public static Dictionary<string, object>? ConvertUsingNewtonsoftJson(JObject person)
        {
            var result = person.ToObject<Dictionary<string, object>>();

            return result;
        }

        public static Dictionary<string, object> ConvertUsingLinq(JObject person)
        {
            var result = person
                        .Properties()
                        .ToDictionary(
                            property => property.Name,
                            property => ConvertJToken(property.Value));

            return result;
        }

        private static object ConvertJToken(JToken token)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    if (token is JObject personObject)
                    {
                        return ConvertUsingLinq(personObject);
                    }
                    break;

                case JTokenType.Array:
                    if (token is JArray jArray)
                    {
                        return ConvertJArrayToListUsingLinq(jArray);
                    }
                    break;

                default:
                    return ((JValue)token).Value!;
            }

            throw new InvalidOperationException("Unsupported JToken type");
        }

        private static List<object> ConvertJArrayToListUsingLinq(JArray jArray)
        {
            return jArray.Select(ConvertJToken).ToList();
        }

    }
}
