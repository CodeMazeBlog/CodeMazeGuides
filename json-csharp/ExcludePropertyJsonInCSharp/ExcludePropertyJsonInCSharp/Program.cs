using ExcludePropertyJsonInCSharp.Models;
using ExcludePropertyJsonInCSharp.Serializers;

namespace ExcludePropertyJsonInCSharp
{
    public static class Program
    {
        public static Person Person => new Person()
        {
            Id = 1,
            Name = "John",
            LastName = "Smith"
        };
        
        public static PersonNewtonsoft PersonNewtonsoft => new PersonNewtonsoft()
        {
            Id = 1,
            Name = "John",
            LastName = "Smith"
        };
        
        public static  Customer Customer => new Customer()
        {
            Id = 1,
            Name = "John",
            LastName = "Smith"
        };

        public static Book Book => new Book()
        {
            Id = 1,
            Title = "Dracula"
        };

        public static Movie Movie => new Movie()
        {
            Id = 1,
            Name = "Titanic",
            Classification = 12,
            Description = "It is based on accounts of the sinking of the RMS Titanic"
        };

        public static void Main(string[] args)
        {
            // Ignore Individual Properties
            var json = MicrosoftSerializer.ExcludePropertyJsonIgnore(Person);
            Console.WriteLine(json);

            json = NewtonsoftSerializer.ExcludePropertyJsonIgnore(PersonNewtonsoft);
            Console.WriteLine(json);

            // DataContract and DataMember Attributes
            json = NewtonsoftSerializer.IncludePropertyDataContract(Customer);
            Console.WriteLine(json);

            // Ignore all null-value properties
            json = MicrosoftSerializer.ExcludeAllNullProperties(Book);
            Console.WriteLine(json);

            json = NewtonsoftSerializer.ExcludeAllNullProperties(Book);
            Console.WriteLine(json);

            // Ignore all default-value properties
            json = MicrosoftSerializer.ExcludeAllDefaultProperties(Book);
            Console.WriteLine(json);

            json = NewtonsoftSerializer.ExcludeAllDefaultProperties(Book);
            Console.WriteLine(json);

            // Ignore using IContractResolver
            json = NewtonsoftSerializer.ExcludeUsingContractResolver(Movie);
            Console.WriteLine(json);
        }
    }
}