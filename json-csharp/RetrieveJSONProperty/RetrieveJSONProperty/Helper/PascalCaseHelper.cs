using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace RetrieveJSONProperty.Helper
{

    public class PascalCaseContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty prop = base.CreateProperty(member, memberSerialization);

            prop.PropertyName = char.ToUpper(prop.PropertyName[0]) + prop.PropertyName.Substring(1);

            return prop;
        }
    }
}

