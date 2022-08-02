using System;

namespace CheckDateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            //Checks for Sat-Sun Weekends

            var date = DateTime.Now;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Weekend");
            }
            else
            {
                Console.WriteLine("Workday");
            }

            date = new DateTime(2021, 10, 10);
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("Weekend");
            }
            else
            {
                Console.WriteLine("Workday");
            }

            //Checks for Fri-Sat Weekends

            date = new DateTime(2021, 10, 10);
            if (date.DayOfWeek == DayOfWeek.Friday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                Console.WriteLine("Weekend");
            }
            else
            {
                Console.WriteLine("Workday");
            }

            //Formatting options

            Console.WriteLine(DateTime.Now.ToString());                                 //Will show as: 12/8/2021 5:30:58 PM
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy"));                     //Will show as: 12/08/2021
            Console.WriteLine(DateTime.Now.ToString("dddd, dd MMMM yyyy"));             //Will show as: Wednesday, 08 December 2021
            Console.WriteLine(DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss"));    //Will show as: Wednesday, 08 December 2021 17:35:32
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm"));               //Will show as: 12/08/2021 17:35
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));            //Will show as: 12/08/2021 05:35 PM
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy H:mm"));                //Will show as: 12/08/2021 17:
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy h:mm tt"));             //Will show as: 12/08/2021 5:35 PM
            Console.WriteLine(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss"));            //Will show as: 12/08/2021 17:35:32

            //Weekday/weekend checks with custom Date formatting

            date = DateTime.Now;
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("The date " + date.ToString("dddd, dd MMMM yyyy") + " is a Weekend day");
            }
            else
            {
                Console.WriteLine("The date " + date.ToString("dddd, dd MMMM yyyy") + " is a Workday");
            }

            date = new DateTime(2021, 10, 10);
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                Console.WriteLine("The date " + date.ToString("dddd, dd MMMM yyyy") + " is a Weekend day");
            }
            else
            {
                Console.WriteLine("The date " + date.ToString("dddd, dd MMMM yyyy") + " is a Workday");
            }
        }
    }
}
