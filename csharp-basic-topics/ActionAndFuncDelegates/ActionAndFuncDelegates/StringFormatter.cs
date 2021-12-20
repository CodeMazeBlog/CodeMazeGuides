namespace CodeMaze
{
    public class StringFormatter
    {
        public string FormatStringAsUppercase(string str)
        {
            var formatted = str.ToUpper();
            Console.WriteLine($"Formats '{str}' as '{formatted}'");

            return formatted;
        }

        public string FormatDateAsString(DateTime time)
        {
            var formatted = time.ToString("yyyyMMddHHmmssfff");
            Console.WriteLine($"Formats '{time}' as '{formatted}'");

            return formatted;
        }
    }
}