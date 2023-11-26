namespace SerializeObjectToQueryString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n***************** Serialize the object to query string using reflection ***************\n");
            Console.WriteLine(QueryStringSerializer.SerializeObjectToQueryStringUsingReflection());

            Console.WriteLine("\n***************** Serialize the object to query string using Newtonsoft Json ***************\n");
            Console.WriteLine(QueryStringSerializer.SerializeObjectToQueryStringUsingNewtonsoftJson());

            Console.WriteLine("\n***************** Serialize the nested object to query string ***************\n");
            Console.WriteLine(QueryStringSerializer.SerializeNestedObjectToQueryString());

            Console.WriteLine("\n***************** Serialize the object that contains array property to query string ***************\n");
            Console.WriteLine(QueryStringSerializer.SerializeObjectContainingArraysToQueryString());
        }
    }
}