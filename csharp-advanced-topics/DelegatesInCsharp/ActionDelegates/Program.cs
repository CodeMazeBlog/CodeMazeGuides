using System;
using System.Collections.Generic;
using System.Globalization;

namespace ActionDelegates
{
    class Program
    {
        static void ShowWeeks(string str)
        {
            Console.WriteLine(str);
        }

        static void GetTitleCaseMessage(string msg)
        {
            string msgTitleCase = CultureInfo.InvariantCulture.TextInfo.ToTitleCase(msg.ToLower()); 
            Console.WriteLine($"Message in Title Case: {msgTitleCase}");
        }

        static void Main(string[] args)
        {
            //*** Use of Action<T> delegate to show the data from the List<T> object ***//
            List<string> weeks = new List<string>();
            weeks.Add("Sunday");
            weeks.Add("Monday");
            weeks.Add("Tuesday");
            weeks.Add("Wednesday");
            weeks.Add("Thursday");
            weeks.Add("Friday");
            weeks.Add("Saturday");

            // Display the weeks using the ShowWeeks method
            weeks.ForEach(ShowWeeks);

            //*** Use of Action<T> delegate ***//
            Console.WriteLine("\n*************Action Delegate*************");
            Action<string> message = GetTitleCaseMessage;
            message("write some text here");

            //*** Use of Action<T> delegate with anonymous method ***//
            Console.WriteLine("\n*************Action Delegate with Anonymous Method*************");
            Action<string> strTitleCase = delegate (string str)
                                        {
                                            GetTitleCaseMessage(str);
                                        };
            strTitleCase("write some text here");

            //*** Use of Action<T> delegate with Lambda expression ***//
            Console.WriteLine("\n*************Action Delegate with Lambda Expression*************");
            Action<string> txtTitleCase = t => GetTitleCaseMessage(t);
            txtTitleCase("write some text here");

            Console.ReadLine();
        }
    }
}
