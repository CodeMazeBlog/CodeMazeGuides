using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace RetrieveJSONProperty.Helper;
public class PascalCaseContractResolver : DefaultContractResolver
{
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        JsonProperty prop = base.CreateProperty(member, memberSerialization);         
        if (!string.IsNullOrEmpty(prop.PropertyName))
        {
            prop.PropertyName = string.Create(prop.PropertyName.Length, prop.PropertyName, (span, propertyName) =>
            {
                propertyName.AsSpan().CopyTo(span);
                span[0] = char.ToUpperInvariant(span[0]);
            });
        }
        return prop;
    }
}

