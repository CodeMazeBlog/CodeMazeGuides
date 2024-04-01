namespace SubstringInString
{
    public static class LinqMethod
    {
        public static void Linqmethod() 
        {
            var input = "The big black bird just blacked out";
            var substring = "b";
            var indices = input.Select((c, i) => i <= input.Length - substring.Length 
            && input.Substring(i, substring.Length) == substring ? i : -1)
                             .Where(i => i != -1);

            foreach (var index in indices)
            {
                Console.WriteLine($"Found '{substring}' at index {index}");
            }
        }

    }
}
