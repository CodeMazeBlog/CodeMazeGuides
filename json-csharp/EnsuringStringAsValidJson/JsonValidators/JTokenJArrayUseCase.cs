using JsonValidators.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonValidators;

public class JTokenJArrayUseCase : IJsonValidator
{
    public bool IsValid(string jsonString)
    {
        try
        {
            if (jsonString.StartsWith("{") && jsonString.EndsWith("}"))
            {
                JToken.Parse(jsonString);
            }
            else if (jsonString.StartsWith("[") && jsonString.EndsWith("]"))
            {
                JArray.Parse(jsonString);
            }
            else
            {
                return false;
            }

            return true;
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}