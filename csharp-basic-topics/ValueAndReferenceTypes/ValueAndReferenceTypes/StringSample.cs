namespace ValueAndReferenceTypes
{
    public class StringSample
    {
        public string PrintWords()
        {
            string string1 = "Welcome";
            string string2 = string1;
            Console.WriteLine($"string1: {string1}");
            Console.WriteLine($"string2: {string2}");
            string2 = "CodeMaze";
            Console.WriteLine($"string1 string2: {string1} {string2}");

            return string2;
        }
    }
}
