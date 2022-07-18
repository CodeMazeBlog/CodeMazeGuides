namespace JsonPolymorphicSerialization
{
    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Address HomeAddress { get; set; } = new Address();
    }
}
