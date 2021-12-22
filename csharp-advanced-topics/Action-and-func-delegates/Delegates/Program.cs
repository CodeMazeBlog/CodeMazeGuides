using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegates // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(ReturnHelloParam1("world"));

            void PrintHelloParam1(string param1)
            {
                Console.WriteLine($"Hello {param1}");
            }
            Action<string> myDelegateAction = PrintHelloParam1;
            myDelegateAction("world with action-delegate");

            string ReturnHelloParam1(string param1)
            {
                return $"Hello {param1}";
            }
            Func<string, string> myDelegateFunc = ReturnHelloParam1;
            Console.WriteLine(myDelegateFunc("world with func-delegate"));

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