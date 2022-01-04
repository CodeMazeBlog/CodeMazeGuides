using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTestSwitch
    {
        [TestMethod]
        public void whenSwitchCaseConstantValue()
        {
            //test for a simple switch case
            var x = 20;
            switch (x) 
            {
                case 10:
                    Console.WriteLine("The value is 10");
                    break;
                case 20:
                    Console.WriteLine("The value is 20");
                    break;
                case 30:
                    Console.WriteLine("The value is 30");
                    break;
                default:
                    Console.WriteLine("Value is not known.");
                    break;
            }
        }
        [TestMethod]
        public void whenSwitchCaseWithPatterns()
        {
            var x = 125;
            string myflower = "Rose";

            switch (x%2)
            {
                case 0:
                    Console.WriteLine($"{x} is an even number");
                    break;
                case 1:
                    Console.WriteLine($"{x} is an odd number");
                    break;
            }
            //switch case example using strings
            switch(myflower)
            {
                case "Jasmine":
                    Console.WriteLine("The flower is Jasmine");
                    break;
                case "Rose":
                    Console.WriteLine("The flower is Rose");
                    break;
                case "Hibiscus":
                    Console.WriteLine("The flower is Hibiscus");
                    break;
                default:
                    Console.WriteLine("No flower selected");
                    break;
            }
           
        }
        [TestMethod]
        public void whenMultipleCasesHaveSameResult()
        {
            var switchValue = 2;
            var Value = 5;
            var resultstring = string.Empty;
            switch (switchValue)
            {
                case 1:
                case 2:
                case 3:
                    resultstring = "one to three";
                    break;
                case 4:
                    resultstring = "four";
                    break;
                default:
                    resultstring = "The result is unknown.";
                    break;
            }
            Console.WriteLine(resultstring);
            // use of when keyword in switch case
            switch (Value)
            {
                case int n when (n >= 1 && n <= 3):
                    Console.WriteLine("The value is between 1 and 3");
                    break;
                case int n when (n >= 4 && n <= 6):
                    Console.WriteLine("The value is between 4 and 6");
                    break;
            }
            // different format for the switch case.
            var resultValue = Value
            switch
            {
                var xi
                when xi == 1 ||
                xi == 2 ||
                xi == 3 => "One to Three",
                4 => "Four",
                5 => "Five",
                _ => "unknown",
            };
            Console.WriteLine(resultValue);
        }

        [TestMethod]
        public void whenSwitchCaseMultipleForNewVersion()
        {
            var swValue = 3;
            var newresult = swValue
            switch
            {
                1 or 2 or 3 => "One to Three",
                4 => "Four",
                5 => "Five",
                _ => "Unknown",
            };
            Console.WriteLine($"{newresult} result is for C# 9.0 syntax");
        }
    }
}