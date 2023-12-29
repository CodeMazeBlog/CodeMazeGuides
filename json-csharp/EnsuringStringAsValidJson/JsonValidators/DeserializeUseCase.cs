using JsonValidators.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace JsonValidators;

public class DeserializeUseCase : IJsonValidator
{
    private readonly string _desiredJsonSchema;

    public DeserializeUseCase()
    {
        _desiredJsonSchema = @"{
            'type': 'object',
            'properties': {
                'name': {'type':'string'},
                'age': {'type': 'integer'}
            },
            'additionalProperties': false
        }";
    }
    
    public bool IsValid(string jsonString)
    {
        try
        {
            using var stringReader = new StringReader(jsonString);
            using var jsonTextReader = new JsonTextReader(stringReader);
            using var validatingReader = new JSchemaValidatingReader(jsonTextReader);
            
            validatingReader.Schema = JSchema.Parse(_desiredJsonSchema);
            var serializer = new JsonSerializer();
            serializer.Deserialize<object>(validatingReader);
            
            return true;
        }
        catch (JsonReaderException e)
        {
            return false;
        }
    }
}