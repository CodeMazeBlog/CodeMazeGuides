using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace RetrieveJSONProperty.Helper;
public static class ResolverHelper
    {
        static readonly IContractResolver defaultResolver = JsonSerializer.CreateDefault().ContractResolver;

        public static JsonProperty GetJsonProperty<T>(T obj, string jsonName, bool exact = false, IContractResolver? resolver = null)
        {
        ArgumentNullException.ThrowIfNull(obj, nameof(obj));

        resolver = resolver ?? defaultResolver;
        var objType = obj.GetType();
        var contract = resolver.ResolveContract(objType) as JsonObjectContract;

        if (contract == null)
            throw new ArgumentException($"{objType} is not serialized as a JSON object");

        var property = contract.Properties.GetProperty(jsonName, exact ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);

        if (property == null)
            throw new ArgumentException($"Property {jsonName} was not found.");

        return property;
    }
}


