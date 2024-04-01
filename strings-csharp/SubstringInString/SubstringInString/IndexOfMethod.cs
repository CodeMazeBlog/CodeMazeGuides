namespace SubstringInString
{
    public static class IndexOfMethod
    {
        public static void Indexofmethod() 
        {
            var input = "Taking a walk in spring is great";
            var substring = "a";
            var startIndex = 0;

            for (var i = input.IndexOf(substring); i != -1; i = input.IndexOf(substring, startIndex))
            {
                Console.WriteLine("Found '{0}' in '{1}' at position {2}",
                                    substring, input, i);

                startIndex = i + 1;
            }

            if (input.IndexOf(substring) == -1)
            {
                Console.WriteLine("The substring was not found in the given string.\n");
            }
        }
    }
}
