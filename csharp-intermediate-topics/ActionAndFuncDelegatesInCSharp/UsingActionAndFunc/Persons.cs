namespace UsingActionAndFunc
{
    public static class Persons
    {
        public static List<Person> GetAll()
        {
            return new List<Person>
            {
                new () { Name = "Jon", Age = 15 },
                new () { Name = "Bob", Age = 20 },
                new () { Name = "Mike", Age = 70 }
            };
        }
    }
}
