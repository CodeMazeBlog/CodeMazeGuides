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

        public JObject AddStringValue(string propertyName, string value)
        {
            var json = JObject.Parse(_json);
            json.Add(propertyName, value);

            return json;
        }

        public JObject AddObjectValue(string propertyName, object value)
        {
            var json = JObject.Parse(_json);
            json.Add(propertyName, JObject.FromObject(value));

            return json;
        }

        public JObject InsertStringValue(string existingProperty, string newProperty, string value)
        {
            var json = JObject.Parse(_json);
            json[existingProperty][newProperty] = value;

            return json;
        }

        public JObject InsertObjectValue(string existingProperty, string newProperty, object value)
        {
            var json = JObject.Parse(_json);
            json[existingProperty][newProperty] = JObject.FromObject(value);

            return json;
        }
    }
}
