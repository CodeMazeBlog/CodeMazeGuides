namespace SerializeObjectToQueryString
{
    public class Program
    {
        private const string BaseApiUrl = "https://test.com";

        static void Main(string[] args)
        {
            Console.WriteLine("\n***************** Serialize the object to query string using reflection ***************\n");
            Console.WriteLine(QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingReflection(BaseApiUrl, new Book()));

            Console.WriteLine("\n***************** Serialize the object to query string using Newtonsoft Json ***************\n");
            Console.WriteLine(QueryStringSerializer.CreateURLWithBookAsQueryParamsUsingNewtonsoftJson(BaseApiUrl, new Book()));

            Console.WriteLine("\n***************** Serialize the nested object to query string ***************\n");
            Console.WriteLine(QueryStringSerializer.CreateURLWithProductAsQueryParams(BaseApiUrl, new Product()));

            Console.WriteLine("\n***************** Serialize the object that contains array property to query string ***************\n");
            Console.WriteLine(QueryStringSerializer.CreateURLWithPersonAsQueryParams(BaseApiUrl, new Person()));

        }
    }
}