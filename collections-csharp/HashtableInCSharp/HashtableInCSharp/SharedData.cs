namespace HashtableInCSharp
{
    public static class SharedData
    {
        public const int InitialCapacity = 100;

        public static Dictionary<int, User> UserDictionary => new(5)
        {
            { 1, new User() { Id = 1, FirstName = "Rafa", LastName = "Lopez" } },
            { 2, new User() { Id = 2, FirstName = "Michael", LastName = "Sam" } },
            { 3, new User() { Id = 3, FirstName = "Sam", LastName = "Manalt" } },
            { 4, new User() { Id = 4, FirstName = "Lone", LastName = "Costa" } },
            { 5, new User() { Id = 5, FirstName = "Alberto", LastName = "Daci" } }
        };

        public static List<User> UserList => new(3)
        {
            new User() { Id = 6, FirstName = "Judit", LastName = "Peter" },
            new User() { Id = 7, FirstName = "Steve", LastName = "Billing" },
            new User() { Id = 8, FirstName = "Goddy", LastName = "Opara" }
        };
    }
}