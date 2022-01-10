using System;

namespace DelegatesInCsharp
{
	class Program
	{
		delegate void Alarm();      // declaring a delegate
        static void Main(string[] args)
        {
            //manualy declaring delegate 
            Alarm alarm;            // creating a veriable
            alarm = WakeUp;         // assigning the address of the method to this variable
            alarm();                // calling a method

            void WakeUp() => Console.WriteLine("Wake up it is already 07:00");
            Console.ReadLine();

            // using Action
            ModifyString("uppercase", StringToUpperCase);   //UPPERCASE
            ModifyString("LOWERCASE", StringToLowerCase);   //lowercase

            void ModifyString(string str, Action<string> op) => op(str);

            void StringToUpperCase(string str) => Console.WriteLine($"String modifeied to UpperCase - {str.ToUpper()}");
            void StringToLowerCase(string str) => Console.WriteLine($"String modifeied to LowerCase - {str.ToLower()}");

            Console.ReadLine();

            //using Func
            int result1 = MathOperation(6, 4, Add); // 10
            Console.WriteLine(result1);

            int result2 = MathOperation(6, 4, Multiply); // 24
            Console.WriteLine(result2);

            int MathOperation(int x, int y, Func<int, int, int> operation) => operation(x, y);
            int Add(int x, int y) => x + y;
            int Multiply(int x, int y) => x * y;
        }
	}
}
