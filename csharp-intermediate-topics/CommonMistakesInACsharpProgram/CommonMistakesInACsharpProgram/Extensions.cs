namespace CommonMistakesInACsharpProgram
{
    public static class Extensions
    {
        public static string PersonExtension(this Person person)
        {
            person.Name ??= "A person";

            Console.WriteLine($"{person.Name} is happy");

            return person.Name;
        }
    }
}
