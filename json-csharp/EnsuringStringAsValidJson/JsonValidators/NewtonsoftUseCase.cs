using JsonValidators.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonValidators;

public class NewtonsoftUseCase : IJsonValidator
{
    public bool IsValid(string jsonString)
    {
        try
        {
            JObject.Parse(jsonString);
            return true;
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}