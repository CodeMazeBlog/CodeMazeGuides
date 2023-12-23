using JsonValidators.Abstracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace JsonValidators;

public class DeserializeUseCase : IJsonValidator
{
    public bool IsValid(string jsonString)
    {
        try
        {
            using var stringReader = new StringReader(jsonString);
            using var jsonTextReader = new JsonTextReader(stringReader);
            using var validatingReader = new JSchemaValidatingReader(jsonTextReader);
            validatingReader.Schema = JSchema.Parse(jsonString);
            var serializer = new JsonSerializer();
            serializer.Deserialize<object>(validatingReader);
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}