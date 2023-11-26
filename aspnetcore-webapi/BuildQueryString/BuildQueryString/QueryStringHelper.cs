using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Web;

namespace BuildQueryString
{
    public class Product
    {
        public string Name { get; set; } = "Laptop";
        public string Category { get; set; } = "Electronics";
        public Manufacturer Manufacturer { get; set; } = new Manufacturer();
    }

    public class Manufacturer
    {
        public string Location { get; set; } = "Silicon Valley";
    }

    public class Person
    {
        public string FirstName { get; set; } = "Smith";
        public int Age { get; set; } = 25;
        public string[] Hobbies { get; set; } = { "Reading", "Traveling", "Gaming" };
    }

    public static class QueryStringHelper
    {
        public static string BuildUrlWithQueryStringUsingStringConcat(
            string basePath, Dictionary<string, string> queryParams)
        {
            var queryString = string.Join("&", queryParams.Select(kvp => $"{HttpUtility.UrlEncode(kvp.Key)}={HttpUtility.UrlEncode(kvp.Value)}"));

            var fullApiUrl = $"{basePath}?{queryString}";
            Console.WriteLine(fullApiUrl);

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingUriBuilder(string basePath, Dictionary<string, string> queryParams)
        {
            var uriBuilder = new UriBuilder(basePath)
            {
                Query = string.Join("&", queryParams.Select(kvp => $"{kvp.Key}={kvp.Value}"))
            };

            var fullApiUrl = uriBuilder.Uri.AbsoluteUri;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingParseQueryStringMethod(
            string basePath, Dictionary<string, string> queryParams)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            foreach (var dict in queryParams)
            {
                query[dict.Key] = dict.Value;
            }

            var fullApiUrl = string.Join("?", basePath, query.ToString());
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingAddQueryStringMethod(
            string basePath, Dictionary<string, string?> queryParams)
        {
            var fullApiUrl = QueryHelpers.AddQueryString(basePath, queryParams);
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingQueryBuilderClass(
            string basePath, Dictionary<string, string> queryParams)
        {
            var queryBuilder = new QueryBuilder(queryParams);

            var fullApiUrl = basePath + queryBuilder;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string BuildUrlWithQueryStringUsingCreateMethod(
            string basePath, Dictionary<string, string?> queryParams)
        {
            var queryString = QueryString.Create(queryParams);

            var fullApiUrl = basePath + queryString;
            Console.WriteLine($"Full API Url: {fullApiUrl}");

            return fullApiUrl;
        }

        public static string SerializeNestedObjectToQueryString(string basePath)
        {
            Product product = new Product();

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
                                                return $"{HttpUtility.UrlEncode(propertyName)}.{HttpUtility.UrlEncode(nestedPropertyName)}={HttpUtility.UrlEncode(nestedPropertyValue)}";
                                            });
                                        }
                                        else
                                        {
                                            return new[] { $"{propertyName}={propertyValue}" };
                                        }
                                    })
                                );

            var full =  $"{basePath}?{finalQueryString}";

            return full;
        }

        public static string SerializeObjectContainingArraysToQueryString(string basePath)
        {
            Person person = new Person();

            var queryString = typeof(Person).GetProperties()
            .SelectMany(property =>
            {
                string propertyName = property.Name;
                object propertyValue = property.GetValue(person)!;

                if (propertyValue is Array arrayValue)
                {
                    return Enumerable.Range(0, arrayValue.Length)
                        .Select(i => $"{propertyName}[{i}]={arrayValue.GetValue(i)}");
                }
                else
                {
                    return new[] { $"{propertyName}={propertyValue}" };
                }
            });

            string finalQueryString = string.Join("&", queryString);

            return $"{basePath}?{finalQueryString}";
        }
    }
}
