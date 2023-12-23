using Json.More;
using JsonValidators.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonValidators;

public class JsonSchemaAgainstDesiredStructureUseCase : IJsonValidator
{
    private readonly string _desiredJsonSchema;

    public JsonSchemaAgainstDesiredStructureUseCase()
    {
        _desiredJsonSchema = @"{
                    'type': 'object',
                    'properties': {
                        'username': {'type':'string'},
                        'addresses': {'type': 'array'}
                    },
                    'additionalProperties': false
                }";
    }

    public bool IsValid(string jsonString)
    {
        try
        {
            var schema = JsonSchema.Parse(_desiredJsonSchema);
            var jObject = JObject.Parse(jsonString);
            
            return jObject.IsValid(schema);
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}