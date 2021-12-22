using System;

namespace ActionAndFunc
{
    class Program
    {
        static void Main(string[] args)
        {
            Action printTitle = new Action(ActionAndFuncMethod.PrintProjectTitle);
            Action<string> enternametoprint = new Action<string>(ActionAndFuncMethod.PrintCustomInput);
            Action<int, int> printRangeOfNumber = new Action<int, int>(ActionAndFuncMethod.PrintRange);

            Func<int, int, int> addTwoNumbers = new Func<int, int, int>(ActionAndFuncMethod.AddTwoNumbers);
            Func<int, int, string> add2WithNarration = new Func<int, int, string>(ActionAndFuncMethod.AddWithNarration);
            Func<string, string, string> FullName = new Func<string, string, string>(ActionAndFuncMethod.ConcatinateName);


            Console.WriteLine("\n***************** Action<> Delegate Methods ***************\n");
            /**
            * printTitle will print project title
            * enternametoprint prints the welcome statement
            * printRangeOfNumber prints numbers between 5 and 10         
            **/
            printTitle();
            enternametoprint("Welcome John Doe");
            printRangeOfNumber(5, 10);

            Console.WriteLine("**************** Func<> Delegate Methods *****************\n");
            /**
             * addition is the result after adding 2 and 5 equals to 7
             * additionwithnarration gives the remarks from the method
             * fullname returns the full name as John Doe        
             **/

            int addition = addTwoNumbers(2, 5);
            string additionwithnarration = add2WithNarration(5, 8);
            string fullname = FullName("John", "Doe");

            Console.WriteLine("Add result for two numbers: {0}", addition);
            Console.WriteLine(additionwithnarration);
            Console.WriteLine(fullname);

            Console.ReadLine();
        }
    }
}
