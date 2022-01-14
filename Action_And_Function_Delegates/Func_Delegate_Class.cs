using System;

namespace Func_Delegates.Pages.Shared
{
    public class Func_Delegate_Class
    {

        // Method
        public static decimal Percentage_Calculation(int marks, int total)
        {
            return (((decimal)marks / total) * 100);
        }

        static public void Main()
        {
            Func<int, int, decimal> Get_Percentage = Percentage_Calculation;

            decimal MarksPercent = Get_Percentage(320, 500);
            
            Console.WriteLine($"{MarksPercent }");
        }
    }
}


