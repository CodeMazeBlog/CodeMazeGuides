namespace ReadXML
{
    public static class People
    {
        private static readonly string[] firstNames = ["John", "Jane", "Robert", "Emily", "Michael",
            "Sarah", "William", "Olivia", "James", "Emma"];
        private static readonly string[] lastNames = ["Smith", "Johnson", "Williams", "Jones", "Brown",
            "Davis", "Miller", "Wilson", "Moore", "Taylor"];

        public static Person GetOne() => Generate().First();

        public static Person[] Get(int numberOfPeople)
            => Generate().Take(numberOfPeople).ToArray();

        private static IEnumerable<Person> Generate()
        {
            while (true)
            {
                var firstName = firstNames[Random.Shared.Next(firstNames.Length)];
                var lastName = lastNames[Random.Shared.Next(lastNames.Length)];

                yield return new Person(
                    FirstName: firstName,
                    LastName: lastName,
                    Email: $"{firstName.ToLower()}.{lastName.ToLower()}@code-maze.com",
                    Birthday: DateTime.Today.AddDays(-Random.Shared.Next(1_000, 25_000))
                );
            }
        }
    }
}
