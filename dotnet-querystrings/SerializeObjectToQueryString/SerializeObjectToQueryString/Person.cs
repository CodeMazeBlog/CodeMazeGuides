namespace SerializeObjectToQueryString
{
    public class Person
    {
        public string FirstName { get; set; } = "Smith";
        public int Age { get; set; } = 25;
        public string[] Hobbies { get; set; } = { "Reading", "Traveling", "Gaming" };
        public Address Address { get; set; } = new Address();
    }

    public class Address
    {
        public string Country { get; set; } = "Australia";
    }
}