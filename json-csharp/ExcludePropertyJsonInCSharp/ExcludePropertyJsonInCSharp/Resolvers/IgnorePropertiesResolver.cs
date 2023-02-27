using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

#pragma warning disable CS8604

namespace ExcludePropertyJsonInCSharp.Resolvers
{
    public class IgnorePropertiesResolver : DefaultContractResolver
    {
        private readonly HashSet<string> ignoreProps;
        public IgnorePropertiesResolver(params string[] propNamesToIgnore)
        {
            ignoreProps = new HashSet<string>(propNamesToIgnore);
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (ignoreProps.Contains(property.PropertyName))
            {
                property.ShouldSerialize = _ => false;
            }

            return property;
        }
    }
}