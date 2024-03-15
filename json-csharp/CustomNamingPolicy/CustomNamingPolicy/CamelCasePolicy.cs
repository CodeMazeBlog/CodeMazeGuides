using System.Text.Json;

namespace CustomNamingPolicy
{
    public class CamelCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            return char.IsUpper(name[0]) ? char.ToLower(name[0]) + name.Substring(1) : name;
        }
    }
}
