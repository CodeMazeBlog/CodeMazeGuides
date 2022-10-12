namespace CommonMistakesInACsharpProgram
{
    public static class Extensions
    {
        public static string PersonExtension(this Person person)
        {
            person.name ??= "A person";

            Console.WriteLine($"{person.name} is happy");

            return person.name;
        }
    }
}
