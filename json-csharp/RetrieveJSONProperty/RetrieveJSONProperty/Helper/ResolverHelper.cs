using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace RetrieveJSONProperty.Helper;

    public static partial class JsonExtensions
    {
        static readonly IContractResolver defaultResolver = JsonSerializer.CreateDefault().ContractResolver;

        public static JsonProperty GetJsonProperty<T>(T obj, string jsonName, bool exact = false, IContractResolver resolver = null)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            resolver = resolver ?? defaultResolver;
            var contract = resolver.ResolveContract(obj.GetType()) as JsonObjectContract;

            if (contract == null)
                throw new ArgumentException($"{obj.GetType()} is not serialized as a JSON object");

            var property = contract.Properties.GetProperty(jsonName, exact ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);

            if (property == null)
                throw new ArgumentException($"Property {jsonName} was not found.");

            return property;
        }
    }


