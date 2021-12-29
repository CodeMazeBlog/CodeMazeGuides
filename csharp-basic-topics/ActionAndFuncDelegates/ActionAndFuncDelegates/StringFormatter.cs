namespace ActionAndFuncDelegates
{
    public class StringFormatter
    {
        public string FormatStringAsUppercase(string str)
        {
            return str.ToUpper();
        }

        public string FormatDateAsString(DateTime dateTime)
        {
            return dateTime.ToString("yyyyMMdd");
        }
    }
}