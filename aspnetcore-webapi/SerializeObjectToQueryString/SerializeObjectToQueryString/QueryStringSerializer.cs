using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web;

namespace SerializeObjectToQueryString
{
    public static class QueryStringSerializer
    {
        private const string BaseApiUrl = "https://test.com";
        public static string SerializeObjectToQueryStringUsingReflection()
        {
            var books = new Books();

            var properties = from p in books
                             .GetType()
                             .GetProperties()
                             where p.GetValue(books, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(books)?.ToString());

            var queryString = string.Join("&", properties.ToArray());

            return $"{BaseApiUrl}?{queryString}";
        }

        public static string SerializeObjectToQueryStringUsingNewtonsoftJson()
        {
            var books = new Books();

            string jsonString = JsonConvert.SerializeObject(books);

            var jsonObject = JObject.Parse(jsonString);

            var properties = jsonObject
                                .Properties()
                                .Where(p => p.Value != null)
                                .Select(p => $"{HttpUtility.UrlEncode(p.Name)}={HttpUtility.UrlEncode(p.Value.ToString())}");

            var queryString = string.Join("&", properties.ToArray());

            return $"{BaseApiUrl}?{queryString}";
        }

        public static string SerializeNestedObjectToQueryString()
        {
            var product = new Product();

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

            return $"{BaseApiUrl}?{finalQueryString}";
        }

        public static string SerializeObjectContainingArraysToQueryString()
        {
            var person = new Person();

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

            string finalQueryString = string.Join("&", queryString);

            return $"{BaseApiUrl}?{finalQueryString}";
        }
    }
}
