using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace OrderPropertyJsonInCSharp.Resolvers
{
    public class OrderedPropertiesJsonTypeInfoResolver: DefaultJsonTypeInfoResolver
    {
        public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
        {
            var order = 0;

            JsonTypeInfo typeInfo = base.GetTypeInfo(type, options);

            if (typeInfo.Kind == JsonTypeInfoKind.Object)
            {
                foreach (JsonPropertyInfo property in typeInfo.Properties.OrderBy(a => a.Name))
                {
                    property.Order = order++;
                }
            }

            return typeInfo;
        }
    }
}
