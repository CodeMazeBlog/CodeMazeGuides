using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Xml.Serialization;

namespace DeepCopyInCSharp
{
    public class DeepCopier
    {
        public static T DeepCopyXML<T>(T obj)
        {
            using var stream = new MemoryStream();

            var serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, obj);
            stream.Position = 0;

            return (T)serializer.Deserialize(stream);
        }

        public static T DeepCopyJSON<T>(T obj)
        {
            var jsonString = JsonSerializer.Serialize(obj);

            return JsonSerializer.Deserialize<T>(jsonString);
        }

        public static T DeepCopyDataContract<T>(T obj)
        {
            using var stream = new MemoryStream();

            var serializer = new DataContractSerializer(typeof(T));
            serializer.WriteObject(stream, obj);
            stream.Position = 0;

            return (T)serializer.ReadObject(stream);
        }

        public static T DeepCopyReflection<T>(T obj)
        {
            var type = obj.GetType();
            var properties = type.GetProperties();

            T clonedObj = (T)Activator.CreateInstance(type);

            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    object value = property.GetValue(obj);
                    if (value != null && value.GetType().IsClass && !value.GetType().FullName.StartsWith("System."))
                    {
                        property.SetValue(clonedObj, DeepCopyReflection(value));
                    }
                    else
                    {
                        property.SetValue(clonedObj, value);
                    }
                }
            }

            return clonedObj;
        }

        public static T DeepCopyExpressionTrees<T>(T input)
        {
            return GenerateDeepCopy<T>()(input);
        }

        private static Func<T, T> GenerateDeepCopy<T>()
        {
            var inputParameter = Expression.Parameter(typeof(T), "input");

            var memberBindings = new List<MemberBinding>();
            foreach (var propertyInfo in typeof(T).GetProperties())
            {
                var propertyExpression = Expression.Property(inputParameter, propertyInfo);

                if (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string))
                {
                    var copyMethod = typeof(DeepCopier)
                        .GetMethod(nameof(DeepCopier.DeepCopyExpressionTrees))
                        .MakeGenericMethod(propertyInfo.PropertyType);

                    var propertyCopyExpression = Expression.Call(copyMethod, propertyExpression);

                    memberBindings.Add(Expression.Bind(propertyInfo, propertyCopyExpression));
                }
                else
                {
                    memberBindings.Add(Expression.Bind(propertyInfo, propertyExpression));
                }
            }

            var memberInitExpression = Expression.MemberInit(Expression.New(typeof(T)), memberBindings);

            return Expression.Lambda<Func<T, T>>(memberInitExpression, inputParameter).Compile();
        }

    }
}
