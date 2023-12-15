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
            var reader = new JsonTextReader(new StringReader(jsonString));
            var validatingReader = new JSchemaValidatingReader(reader);
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