using System;

namespace DelegatesInCsharp
{
	class Program
	{
        static public void Main()
        {
            //Func Delegate
            Func<int, int, decimal> Get_Percentage = Func_Delegates.Func_Delegate_Class.Percentage_Calculation;
            decimal MarksPercent = Get_Percentage(320, 500);
            Console.WriteLine($"{MarksPercent }");

            //Action Delegate
            Action<string, string> Concate =Action_Delegates.Action_Delegate_Class.GetCompleteName;
            Concate("Ricky", "Martin ");
        }
    }
}