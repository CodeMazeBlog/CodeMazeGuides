namespace SubstringInString
{
    public static class SubstringMethod
    {
        public static void Substringmethod()
        {
            var input = "This is a substring method for searching for substrings in a string";
            var input2 = "sub";

            var count = 0;
            var inputLength = input.Length;
            var searchLength = input2.Length;

            for (var i = 0; i <= inputLength - searchLength; i++)
            {
                if (input.Substring(i, searchLength) == input2)
                {
                    count++;
                    Console.WriteLine("Found '{0}' in '{1}' at position {2}", input2, input, i);
                }
            }

            if (count == 0)
            {
                Console.WriteLine("The substring was not found in the given string.");
            }
            else
            {
                Console.WriteLine("Total occurrences found: {0}", count);
            }
        }

    }
}

