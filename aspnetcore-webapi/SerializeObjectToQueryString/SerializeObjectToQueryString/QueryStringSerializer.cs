using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace SerializeObjectToQueryString
{
    public static class QueryStringSerializer
    {
        private static string SerializeObjectToQueryStringUsingReflection(Book book)
        {
            var properties = from p in book
                                 .GetType()
                                 .GetProperties()
                             where p.GetValue(book, null) != null
                             select HttpUtility.UrlEncode(p.Name) + "=" 
                             + HttpUtility.UrlEncode(p.GetValue(book)?.ToString());

            return string.Join("&", properties.ToArray());
        }

        private static string SerializeObjectToQueryStringUsingNewtonsoftJson(Book book)
        {
            string jsonString = JsonConvert.SerializeObject(book);

            var jsonObject = JObject.Parse(jsonString);

            var properties = jsonObject
                                .Properties()
                             .Where(p => p.Value != null)
                             .Select(p => $"{HttpUtility.UrlEncode(p.Name)}={HttpUtility.UrlEncode(p.Value.ToString())}");

            return string.Join("&", properties.ToArray());
        }

        private static string SerializeNestedObjectToQueryString(Product product)
        {
            var finalQueryString = string.Join('&',
                  typeof(Product).GetProperties().SelectMany(property =>
                  {
                      string propertyName = property.Name;
                      object propertyValue = property.GetValue(product)!;

                      if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
                      {
                          return property.PropertyType.GetProperties().Select(nestedProperty =>
                          {
                              string nestedPropertyName = nestedProperty.Name;
                              string nestedPropertyValue = nestedProperty.GetValue(propertyValue)!.ToString()!;
                              return $"{HttpUtility.UrlEncode(propertyName)}" +
                              $".{HttpUtility.UrlEncode(nestedPropertyName)}={HttpUtility.UrlEncode(nestedPropertyValue)}";
                          });
                      }
                      else
                      {
                          return new[] { $"{propertyName}={propertyValue}" };
                      }
                  })
              );

            return finalQueryString;
        }

        private static string SerializeObjectContainingArraysToQueryString(Person person)
        {
            var queryString = typeof(Person).GetProperties()
            .SelectMany(property =>
            {
                string propertyName = property.Name;
                object propertyValue = property.GetValue(person)!;

                if (propertyValue is Array arrayValue)
                {
                    return Enumerable.Range(0, arrayValue.Length)
                        .Select(i => 
                        $"{HttpUtility.UrlEncode(propertyName)}[{i}]=" +
                        $"{HttpUtility.UrlEncode(arrayValue.GetValue(i)?.ToString())}");
                }
                else
                {
                    return new[] { $"{propertyName}={propertyValue}" };
                }
            });

            return string.Join("&", queryString);
        }

        public static string CreateURLWithBookAsQueryParamsUsingReflection(string url, Book book)
        {
            var queryParams = SerializeObjectToQueryStringUsingReflection(book);

            return $"{url}?{queryParams}";
        }

        public static string CreateURLWithBookAsQueryParamsUsingNewtonsoftJson(string url, Book book)
        {
            var queryParams = SerializeObjectToQueryStringUsingNewtonsoftJson(book);

            return $"{url}?{queryParams}";
        }

        public static string CreateURLWithProductAsQueryParams(string url, Product product)
        {
            var queryParams = SerializeNestedObjectToQueryString(product);

            return $"{url}?{queryParams}";
        }

        public static string CreateURLWithPersonAsQueryParams(string url, Person person)
        {
            var queryParams = SerializeObjectContainingArraysToQueryString(person);

            return $"{url}?{queryParams}";
        }
    }
}
