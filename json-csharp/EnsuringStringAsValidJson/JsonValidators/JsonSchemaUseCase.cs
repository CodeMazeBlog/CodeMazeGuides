using System.Text.Json;
using System.Text.Json.Nodes;
using Json.Schema;
using JsonValidators.Abstracts;

namespace JsonValidators;

public class JsonSchemaUseCase : IJsonValidator
{
    private readonly JsonSchema _desiredJsonSchema;

    public JsonSchemaUseCase()
    {
        _desiredJsonSchema = new JsonSchemaBuilder()
            .Properties(
                ("name", new JsonSchemaBuilder()
                    .Type(SchemaValueType.String)
                    .MinLength(10)
                ),
                ("age", new JsonSchemaBuilder()
                    .Type(SchemaValueType.Integer)
                )
            )
            .Required("name")
            .Required("age");
    }

    public bool IsValid(string jsonString)
    {
        try
        {
            var jsonNode = JsonNode.Parse(jsonString);
            var evaluationResults = _desiredJsonSchema.Evaluate(jsonNode);
            
            return evaluationResults.IsValid;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}