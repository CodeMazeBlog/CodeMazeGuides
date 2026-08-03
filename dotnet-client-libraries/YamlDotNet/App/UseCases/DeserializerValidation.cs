using System.ComponentModel.DataAnnotations;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using static System.Environment;

namespace App.UseCases;

public class DeserializerValidation(INodeDeserializer nodeDeserializer) : INodeDeserializer
{
    public bool Deserialize(IParser reader, Type expectedType, Func<IParser, Type, object?> nestedObjectDeserializer,
        out object? value)
    {
        if (!nodeDeserializer.Deserialize(reader, expectedType, nestedObjectDeserializer, out value))
            return false;

        var context = new ValidationContext(value);
        var results = new List<ValidationResult>();
        if (Validator.TryValidateObject(value, context, results, true))
            return true;

        var message = string.Join(NewLine, results.Select(r => r.ErrorMessage));
        throw new YamlException(message);
    }
}