namespace StaticVsNonStaticMethodsInCsharp
{
    public static class ExtensionMethods
    {
        public static int FindSearchedElementIndex(this string[] str, string searchedWord)
        {
            var index = 0;
            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == searchedWord)
                    index = i;
            }

            Console.WriteLine("Index of searched element: " + index);
            return index;
        }
    }
}
