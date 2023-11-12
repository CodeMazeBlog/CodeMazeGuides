using System.Text.Json;

namespace CustomNamingPolicy
{
    public class FlatCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLower();
    }
}
