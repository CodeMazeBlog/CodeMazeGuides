using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        delegate void myDelegate(string param1);

        public static void Main(string[] args)
        {
            Console.WriteLine(ReturnHelloParam1("world"));


            //Example Action-delegate
            //Method without return value
            void PrintHelloParam1(string param1)
            {
                Console.WriteLine($"Hello {param1}");
            }
            //Defining an Action-delegate
            Action<string> myDelegateAction = PrintHelloParam1;
            //Executing the method trough the Action-delegate
            myDelegateAction("world with action-delegate");


            //Example Func-delegate
            string ReturnHelloParam1(string param1)
            {
                return $"Hello {param1}";
            }
            Func<string, string> myDelegateFunc = ReturnHelloParam1;
            Console.WriteLine(myDelegateFunc("world with func-delegate"));

            
            //Example of simple switch-case
            void IsItFridayYet(DayOfWeek dayOfWeek)
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Monday: { Console.WriteLine("No, it's Monday..."); break; }
                    case DayOfWeek.Tuesday: { Console.WriteLine("No, it's Tuesday..."); break; }
                    case DayOfWeek.Wednesday: { Console.WriteLine("No, it's Wednesday..."); break; }
                    case DayOfWeek.Thursday: { Console.WriteLine("No, it's Thursday..."); break; }
                    case DayOfWeek.Friday: { Console.WriteLine("Yeeeeeeey it is Friday!!!"); break; }
                    case DayOfWeek.Saturday: { Console.WriteLine("No, it's Saturday."); break; }
                    case DayOfWeek.Sunday: { Console.WriteLine("No, it's Sunday."); break; }
                }
            }
            IsItFridayYet(DateTime.Now.DayOfWeek);


            //Dictionary of actions
            var isItFridayYetActions = new Dictionary<DayOfWeek, Action>
            {
              {DayOfWeek.Monday, () => Console.WriteLine("No, it's Monday...")},
              {DayOfWeek.Tuesday, () => Console.WriteLine("No, it's Tuesday...")},
              {DayOfWeek.Wednesday, () => Console.WriteLine("No, it's Wednesday...")},
              {DayOfWeek.Thursday, () => Console.WriteLine("No, it's Thursday...")},
              {DayOfWeek.Friday, () => Console.WriteLine("Yeeeeeeey it's Friday !!!")},
              {DayOfWeek.Saturday, () => Console.WriteLine("No, it's Saturday.")},
              {DayOfWeek.Sunday, () => Console.WriteLine("No, it's Sunday.")}
            };
            isItFridayYetActions[DateTime.Now.DayOfWeek].Invoke();

        }
    }
}