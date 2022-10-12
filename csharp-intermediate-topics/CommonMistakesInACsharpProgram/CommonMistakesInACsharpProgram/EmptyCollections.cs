namespace CommonMistakesInACsharpProgram
{
    partial class Application
    {
        public class EmptyCollections
        {
            public static List<int> Main()
            {
                List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                return numbers.Where(x => x % 2 == 0).ToList();

            }

            public static IEnumerable<Person> GetUserByName(string name = null)
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return Enumerable.Empty<Person>();
                }
                List<Person> users = new() { new Person { age = 12, name = "John" }, new Person { age = 3, name = "doe" }, };

                return users.Where(x => x.name == name);
            }
        }
    }
}
