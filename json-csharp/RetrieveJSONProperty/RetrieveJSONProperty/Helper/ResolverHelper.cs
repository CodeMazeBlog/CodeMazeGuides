using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace RetrieveJSONProperty.Helper;

public static class ResolverHelper
{
    private static readonly IContractResolver _defaultResolver = JsonSerializer.CreateDefault().ContractResolver;

    public static JsonProperty GetJsonProperty<T>(T obj, string jsonName, bool exact = false, IContractResolver? resolver = null)
    {
        ArgumentNullException.ThrowIfNull(obj);

        resolver ??= _defaultResolver;
        var objType = typeof(T);
        
        if (resolver.ResolveContract(objType) is not JsonObjectContract contract)
            throw new ArgumentException($"{objType} is not serialized as a JSON object");

        var property = contract.Properties.GetProperty(jsonName, exact ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);

        if (property == null)
            throw new ArgumentException($"Property {jsonName} was not found.");

        return property;
    }
}