using System.Text.Json;
using Json.More;
using Json.Schema;
using JsonValidators.Abstracts;

namespace JsonValidators;

public class JsonSchemaSimpleValidationUseCase : IJsonValidator
{
    public bool IsValid(string jsonString)
    {
        try
        {
            var jsonSchema = JsonSchema.FromText(jsonString);
            var evaluationResults = jsonSchema.Evaluate(jsonSchema.ToJsonDocument());
            
            return evaluationResults.IsValid;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}