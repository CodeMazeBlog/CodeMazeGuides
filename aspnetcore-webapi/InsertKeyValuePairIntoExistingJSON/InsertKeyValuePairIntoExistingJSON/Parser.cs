using Newtonsoft.Json.Linq;

namespace InsertKeyValuePairIntoExistingJSON
{
    public class Parser
    {
        private string _json;

        public Parser(string json)
        {
            _json = json;
        }

        public string AddStringValue(string key, string value)
        {
            var json = JObject.Parse(_json);
            json.Add(key, value);

            return json.ToString();
        }

        public string AddObjectValue(string key, object value)
        {
            var json = JObject.Parse(_json);
            json.Add(key, JObject.FromObject(value));

            return json.ToString();
        }

        public string InsertStringValue(string existingProperty, string newProperty, string value)
        {
            var json = JObject.Parse(_json);
            if (!json.ContainsKey(existingProperty))
            {
                return json.ToString();
            }

            json[existingProperty][newProperty] = value;

            return json.ToString();
        }

        public string InsertObjectValue(string existingProperty, string newProperty, object value)
        {
            var json = JObject.Parse(_json);
            if (!json.ContainsKey(existingProperty))
            {
                return json.ToString();
            }

            json[existingProperty][newProperty] = JObject.FromObject(value);

            return json.ToString();
        }
    }
}
