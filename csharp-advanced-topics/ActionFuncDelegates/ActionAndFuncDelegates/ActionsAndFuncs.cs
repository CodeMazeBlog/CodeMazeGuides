using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionAndFuncDelegates
{
    public class ActionsAndFuncs
    {
        public string LastGreetedName { get; set; }

        public delegate double MyMethod(double x, double y);
        
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static bool IsNumberEven(int x)
        {
            return x % 2 == 0;
        }

        public void GreetUser(int age, string s)
        {
            Action<string> actionDelegate;
            if (age < 18)
                actionDelegate = (name) => { LastGreetedName = name; Console.WriteLine("Hi kid with name " + name); };
            else
                actionDelegate = (name) => { LastGreetedName = name; Console.WriteLine("Hi old person, your name is: " + name); };
            actionDelegate(s);
        }
        static void Main(string[] args)
        {
            //delegates
            MyMethod doubleDelegate = (x, y) => x + y;
            MyMethod addNumbersDelegate = Add;

            doubleDelegate = (x, y) => x * y; //Change the value of the doubleDelegate variable
            double myVal = doubleDelegate(2, 3); // myVal is 6

            //Func
            Func<double, double, double> myFuncDelegate = (x, y) => x * y;

            myVal = myFuncDelegate(2, 4); //myVal is 8


            //------------ Func with Where
            List<int> numbers = new List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Func<int, bool> isEvenFunc = x => x % 2 == 0;

            var evenNumbersByAnonymousMethod = numbers.Where(x => x % 2 == 0); //Use a lambda expression
            var evenNumbersByFunc = numbers.Where(isEvenFunc); //Use a Func
            var evenNumbersByExistingMethod = numbers.Where(IsNumberEven); //Use a previously declared method


            //Action
            ActionsAndFuncs p = new ActionsAndFuncs();
            p.GreetUser(10, "Kiddie");
            p.GreetUser(30, "John");

            Console.ReadLine();
        }


    }
}
