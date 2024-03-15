using System.Text.Json;
using JsonValidators.Abstracts;

namespace JsonValidators;

public class SystemTextJsonUseCase : IJsonValidator
{
    public bool IsValid(string jsonString)
    {
        try
        {
            JsonDocument.Parse(jsonString);
            
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}