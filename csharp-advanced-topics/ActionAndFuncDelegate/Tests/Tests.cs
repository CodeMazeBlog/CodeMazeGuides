using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Tests
{
    [TestClass]
    public class Tests
    {
        const char delimeter = ' ';
        const string format = "dddd, MMMM dd yyyy";
        static string actionMethodReturn = string.Empty;

        [TestMethod]
        public void whenStringIsSent_DelegateExecutesPrintTextMethodWithTwoArgs()
        {
            Action<string, string> action = PrintText;
            action("Hello", "World!");
            Assert.AreEqual("Hello World!", actionMethodReturn);
        }

        [TestMethod]
        public void whenStringIsSent_DelegateExecutesPrintTextMethodWithThreeArgs()
        {
            Action<string, string, string> action = PrintText;
            action("All", "The", "Best!");
            Assert.AreEqual("All The Best!", actionMethodReturn);
        }

        [TestMethod]
        public void whenStringIsSent_DelegateExecutesCrateDateStringMethod()
        {
            Func<int, int, int, string, string> func = CrateDateString;
            var result = string.Concat("Last date of year is ", func(2021, 12, 31, format));
            Assert.AreEqual("Last date of year is Friday, December 31 2021", result);
        }

        static void PrintText(string first, string second)
        {
            actionMethodReturn = string.Concat(first, delimeter, second);
        }
        static void PrintText(string first, string second, string third)
        {
            actionMethodReturn = string.Concat(first, delimeter, second, delimeter, third);
        }

        static string CrateDateString(int day, int second, int third, string format)
        {
            return new DateTime(day, second, third).ToString(format);
        }
    }
}