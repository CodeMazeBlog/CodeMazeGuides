namespace ConvertListOfStringToCommaSeparatedString
{
    public class SimpleList
    {
        public string ConvertListOfStringsToCommaSeparatedString()
        {
            var sampleList = new List<string> { "Hello", "From", "Code Maze" };
            var commaSeparatedString = string.Join(",", sampleList);
            return commaSeparatedString; 
        }
    }
}
