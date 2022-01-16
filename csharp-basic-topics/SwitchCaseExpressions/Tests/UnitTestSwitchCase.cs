using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public static class TestExtension
    {
        public static bool In<T>(this T val, params T[] vals) => vals.Contains(val);

        [TestMethod]
        static void whenSwitchCaseWithExtensionMethod()
        {
            var tempValue = 20;
            var templist = new List<int> { 20, 22, 24 };

            var result = tempValue switch
            {
                var x when x.In(20, 22, 24) => "It is a pleasant day",
                30 => "It is hot today",
                35 => "It is very hot today",
                _ => "No weather report.",
            };

            Console.WriteLine($"{result} - with extension method");
        }
    }

    [TestClass]
    public class UnitTestSwitch
    {
        [TestMethod]
        public void whenMultipleCasesHaveSameResult()
        {
           var switchTemp = 20;
           var resultstring = string.Empty;

            switch (switchTemp)
            {
                case 20:
                case 22:
                case 24:
                    resultstring = "It is a pleasant day";
                    break;
                case 30:
                    resultstring = "It is a very hot day";
                    break;
                default:
                    resultstring = "No weather report today.";
                    break;
            }

            Console.WriteLine(resultstring);
        }

        [TestMethod]
        public void whenMultipleCasesUseWhenKeyword()
        {
            var switchTemp = 20;
            var value = 100;

            switch (value)
            {
                case int n when (n >= 50 && n <= 150):
                    Console.WriteLine("The value is between 50 and 150");
                    break;
                case int n when (n >= 150 && n <= 200):
                    Console.WriteLine("The value is between 150 and 200");
                    break;
                default:
                    Console.WriteLine("The number is not within the given range.");
                    break;
            }

            var resultValue = switchTemp switch
            {
                var xi when
                (xi >= 20 && xi <= 22) || (xi <= 25) => "Pleasant weather today",
                30 => "It is hot today",
                35 => "It is too hot today",
                _ => "No weather report",
            };

            Console.WriteLine(resultValue);
        }

        [TestMethod]
        public void whenSwitchCaseWithEasyFormat()
        {
            var tempValue = 22;
            var templist = new List<int> { 20, 22, 24 };

            var newresult = tempValue switch
            {
                var x when templist.Contains(x) => "The weather is pleasant",
                30 => "It is hot today",
                35 => "It is very hot today",
                _ => "No weather report",
            };

            Console.WriteLine($"{newresult} - result when using a list");

            var resultText = tempValue switch
            {
                20 or 22 or 24 => "Pleasant weather today",
                30 => "It is quite hot today",
                35 => "It is very hot today",
                > 35 => "Heat wave condition",
                _ => "No weather report.    ",
            };

            Console.WriteLine($"{resultText} - result is for C# 9.0 syntax");
        }
    }
}
