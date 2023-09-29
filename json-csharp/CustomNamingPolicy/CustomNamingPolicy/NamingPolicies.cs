using System.Text.Json;

namespace CustomNamingPolicy
{
    public class FlatCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLower();
    }
    public class CamelCasePolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            var stringArray = name.ToCharArray();

            if (char.IsUpper(stringArray[0]))
            {
                stringArray[0] = char.ToLower(stringArray[0]);
            }

            return new string(stringArray);
        }
    }
}
