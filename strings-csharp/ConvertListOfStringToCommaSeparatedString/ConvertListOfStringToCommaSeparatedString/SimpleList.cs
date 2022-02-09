namespace ConvertListOfStringToCommaSeparatedString
{
    public class SimpleList
    {
        public string ConvertListOfStringsToCommaSeparatedString()
        {
            IList<string> sampleList = new List<string> { "Hello", "From", "Code Maze" };
            string commaSeparatedString = string.Join(",", sampleList);
            return commaSeparatedString; 
        }
    }
}
