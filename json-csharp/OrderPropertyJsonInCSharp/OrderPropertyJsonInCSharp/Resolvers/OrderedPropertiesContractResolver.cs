using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OrderPropertyJsonInCSharp.Resolvers
{
    public class OrderedPropertiesContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);

            return properties.OrderBy(p => p.PropertyName).ToList();
        }
    }
}