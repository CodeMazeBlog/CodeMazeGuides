using System.ComponentModel.DataAnnotations;

namespace DynamicQueriesInCSharp.Entities
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Age { get; set; }

        public Address? Address { get; set; }
    }
}
