namespace TestProject1
{


    public class Tests
    {
        public static void AppendPrint(string first, string last) => Console.WriteLine($"{first + " " + last}");
        public static string AppendText(string firstText, string lastText)
        {

            return firstText + " " + lastText;
        }
        [Test]
        public void whenStringsAreSent_DelegateExecutesAppendTextMethod()
        {
            Func<string, string, string> func = AppendText; 
            var result = func("South", "Africa");
            Assert.Pass(result);
        }

        [Test]
        public void whenStringsAreSent_DelegateExecutesAppendPrint()
        {
            Action<string,string> writeDelegate = AppendPrint;
            writeDelegate("United", "Kingdom");
            Assert.Pass();
        }
    }
}