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

        public string Add(string key, string value)
        {
            var json = JObject.Parse(_json);
            json.Add(key, value);

            return json.ToString();
        }

        public string Insert(string existingProperty, string newProperty, string value)
        {
            var json = JObject.Parse(_json);
            if (!json.ContainsKey(existingProperty))
            {
                return json.ToString();
            }

            json[existingProperty][newProperty] = value;

            return json.ToString();
        }
    }
}
