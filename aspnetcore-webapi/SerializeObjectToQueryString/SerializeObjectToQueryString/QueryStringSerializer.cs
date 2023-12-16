using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Web;

namespace SerializeObjectToQueryString
{
    public static class QueryStringSerializer
    {
        private static string ToQueryStringUsingReflection<T>(T obj)
        {
            var properties = from p in obj?
                                 .GetType()
                                 .GetProperties()
                             where p.GetValue(obj, null) != null
                             select $"{HttpUtility.UrlEncode(p.Name)}" +
                             $"={HttpUtility.UrlEncode(p.GetValue(obj)?.ToString())}";

            return string.Join("&", properties);
        }

        private static string ToQueryStringUsingNewtonsoftJson<T>(T obj)
        {
            string jsonString = JsonConvert.SerializeObject(obj);

            var jsonObject = JObject.Parse(jsonString);

            var properties = jsonObject
                .Properties()
                .Where(p => p.Value.Type != JTokenType.Null)
                .Select(p =>
                    $"{HttpUtility.UrlEncode(p.Name)}={HttpUtility.UrlEncode(p.Value.ToString())}");


            return string.Join("&", properties);
        }

        public static string NestedObjectToQueryString(Product product)
        {
            var propValues = GetNestedPropertyValues(product);

            return string.Join('&', propValues);
        }

        private static string ObjectWithArrayAndNestedObjectToQueryString(Person person)
        {
            var propValues = GetNestedPropertyValues(person);

            var finalQueryString = string.Join('&', propValues);

            return finalQueryString;
        }

        private static IEnumerable<string> GetNestedPropertyValues(object obj)
        {
            return obj.GetType().GetProperties()
                .SelectMany(nestedProperty => GetPropertyValues(nestedProperty, obj));
        }

        private static IEnumerable<string> GetArrayValues(string propertyName, Array array)
        {
            return Enumerable.Range(0, array.Length)
                .Select(i =>
                {
                    string arrayElementValue = HttpUtility.UrlEncode(array.GetValue(i)?.ToString()) ?? string.Empty;         
                    return $"{HttpUtility.UrlEncode(propertyName)}[{i}]={arrayElementValue}";
                });
        }

        private static IEnumerable<string> GetPropertyValues(PropertyInfo property, object parentObject)
        {
            string propertyName = property.Name;
            object propertyValue = property.GetValue(parentObject)!;

            if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
            {
                if (property.PropertyType.IsArray)
                {
                    return GetArrayValues(propertyName, (Array)propertyValue);
                }
                else
                {
                    return GetNestedPropertyValues(propertyValue)
                        .Select(nestedValue =>
                            $"{HttpUtility.UrlEncode(propertyName)}.{HttpUtility.UrlEncode(nestedValue)}");
                }
            }
            else
            {
                return new[] { $"{HttpUtility.UrlEncode(propertyName)}={HttpUtility.UrlEncode(propertyValue.ToString())}" };
            }
        }

        public static string CreateURLWithBookAsQueryParamsUsingReflection(string url, Book book)
        {
            var queryParams = ToQueryStringUsingReflection(book);

            return $"{url}?{queryParams}";
        }

        public static string CreateURLWithBookAsQueryParamsUsingNewtonsoftJson(string url, Book book)
        {
            var queryParams = ToQueryStringUsingNewtonsoftJson(book);

            return $"{url}?{queryParams}";
        }

        public static string CreateURLWithProductAsQueryParams(string url, Product product)
        {
            var queryParams = NestedObjectToQueryString(product);

            return $"{url}?{queryParams}";
        }

        public static string CreateURLWithPersonAsQueryParams(string url, Person person)
        {
            var queryParams = ObjectWithArrayAndNestedObjectToQueryString(person);

            return $"{url}?{queryParams}";
        }
    }
}
