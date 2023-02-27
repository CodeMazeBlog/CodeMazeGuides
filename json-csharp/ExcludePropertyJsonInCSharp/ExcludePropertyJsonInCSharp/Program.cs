using ExcludePropertyJsonInCSharp.Models;
using ExcludePropertyJsonInCSharp.Serializers;

namespace ExcludePropertyJsonInCSharp
{
    public static class Program
    {
        public static readonly Person person = new Person()
        {
            Id = 1,
            Name = "John",
            LastName = "Smith"
        };

        public static readonly PersonNewtonsoft personNewtonsoft = new PersonNewtonsoft()
        {
            Id = 1,
            Name = "John",
            LastName = "Smith"
        };

        public static readonly Customer customer = new Customer()
        {
            Id = 1,
            Name = "John",
            LastName = "Smith"
        };

        public static readonly Book book = new Book()
        {
            Id = 1,
            Title = "Dracula"
        };

        public static readonly Movie movie = new Movie()
        {
            Id = 1,
            Name = "Titanic",
            Classification = 12,
            Description = "It is based on accounts of the sinking of the RMS Titanic"
        };

        public static void Main(string[] args)
        {
            // Ignore Individual Properties
            MicrosoftSerializer.ExcludePropertyJsonIgnore(person);
            NewtonsoftSerializer.ExcludePropertyJsonIgnore(personNewtonsoft);

            // DataContract and DataMember Attributes
            NewtonsoftSerializer.IncludePropertyDataContract(customer);

            // Ignore all null-value properties
            MicrosoftSerializer.ExcludeAllNullProperties(book);
            NewtonsoftSerializer.ExcludeAllNullProperties(book);

            // Ignore all default-value properties
            MicrosoftSerializer.ExcludeAllDefaultProperties(book);
            NewtonsoftSerializer.ExcludeAllDefaultProperties(book);

            // Ignore using IContractResolver
            NewtonsoftSerializer.ExcludeUsingContractResolver(movie);
        }
    }
}