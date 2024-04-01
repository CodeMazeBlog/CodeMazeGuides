namespace SubstringInString
{
    public static class SplitMethod
    {
        public static void Splitmethod() 
        {
            var separatingStrings = new string[] { " " };

            var text = "Bring the bricks to the brown box of brooks.";

            var words = text.Split(separatingStrings, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length; i++)
            {
                Console.WriteLine($"Index {i}: <{words[i]}>");
            }
        }
    }
}
