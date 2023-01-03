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

        public JObject AddStringValue(string key, string value)
        {
            var json = JObject.Parse(_json);
            json.Add(key, value);

            return json;
        }

        public JObject AddObjectValue(string key, object value)
        {
            var json = JObject.Parse(_json);
            json.Add(key, JObject.FromObject(value));

            return json;
        }

        public JObject InsertStringValue(string existingProperty, string newProperty, string value)
        {
            var json = JObject.Parse(_json);
            if (!json.ContainsKey(existingProperty))
            {
                return json;
            }

            json[existingProperty][newProperty] = value;

            return json;
        }

        public JObject InsertObjectValue(string existingProperty, string newProperty, object value)
        {
            var json = JObject.Parse(_json);
            if (!json.ContainsKey(existingProperty))
            {
                return json;
            }

            json[existingProperty][newProperty] = JObject.FromObject(value);

            return json;
        }
    }
}
