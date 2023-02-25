using System;
using System.Text.RegularExpressions;

namespace DelegatesInCsharp
{
	class Program
	{
        

		static void Main(string[] args)
		{
            //Action Delegates
            Action<string> printUpperCase = (s) => Console.WriteLine(s.ToUpper());
            Action<string> printLowerCase = (s) => Console.WriteLine(s.ToLower());
            Action<string> printCapitzalizeCase = (s) => Console.WriteLine(Regex.Replace(s, @"((^\w)|(\s|\p{P})\w)",
                                            match => match.Value.ToUpper()));
                       
            printUpperCase("This is an Action delegate");
            printLowerCase("This is an Action delegate");
            printCapitzalizeCase("This is an Action delegate");

            //Func delegates
            Func<int, int, int> add = (x, y) => x + y;
            Func<int, int, int> sub = (x, y) => x - y;
            Func<int, int, int> mult = (x, y) => x * y;
            Func<int, int, int> div = (x, y) => x / y;

            int sum = add(2, 3);
            int substraction = sub(sum, 3);
            int multiplication = mult(sum, 3);
            int division = div(sum, 3);

        }
    }
}
