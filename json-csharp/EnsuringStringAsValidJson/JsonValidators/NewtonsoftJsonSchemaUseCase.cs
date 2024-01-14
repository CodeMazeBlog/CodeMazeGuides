using JsonValidators.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

namespace JsonValidators;

public class NewtonsoftJsonSchemaUseCase : IJsonValidator
{
    private readonly string _desiredJsonSchema;

    public NewtonsoftJsonSchemaUseCase()
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
            var schema = JSchema.Parse(_desiredJsonSchema);
            var jObject = JObject.Parse(jsonString);
            
            return jObject.IsValid(schema);
        }
        catch (JsonReaderException)
        {
            return false;
        }
    }
}