using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionFuncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tradition way Func
            Func<string, string, string> func; func = GetFunc;
            string GetFunc(string a, string b)
            { 
                return string.Concat(a, b); 
            }
            Console.WriteLine(func("Pop", "Song"));

            //Tradition way Action

            Action<int, int, int> action; action = GetAction;
            static void GetAction(int a, int b, int c) 
            {
                Console.WriteLine(a + b + c); 
            }
            action(1, 1, 1);

            //Lamda Action

            Action<int, int, int> action1 = (a, b, c) => Console.WriteLine(a + b + c);
            action1(11, 11, 11);

            //Lamda func

            Func<int, int, int> func1 = (a, b) => (a + b); Console.WriteLine((func1(12, 12)));

            //anonymous method Func
            Func<int, int, int> getRandomNumber = delegate (int min, int max) 
            { 
                var rnd = new Random();
              return rnd.Next(min, max); 
            };
            Console.WriteLine(getRandomNumber(1, 45));

            //anonymous method action

            Action<int> checkNumberevenodd = delegate (int value) 
            { if (value % 2 == 0) 
                { Console.WriteLine(value + " is even ");
                } 
                else Console.WriteLine(value + " is odd ");
            }; 
            checkNumberevenodd(3);

            //real example func

            //Create list of numbers
            List<int> list = new List<int>() { 1, 3, 2, 5, 2, 1 }; 
            //Traditional way of using func delegate
            Func<int, bool> func3 = checkeven;
            bool checkeven(int i) 
            {
                return i % 2 == 0; 
            } 
            var A1 = list.Where(func3);
            foreach (var item in A1)
            { 
                Console.WriteLine(item); 
            } 
            //Using lambda expression for func delegate 
            var a = list.Where(x => x % 2 == 0);
            foreach (var item in a) 
            { 
                Console.WriteLine(item); 
            } 
            // Using anonymous 
            var a1 = list.Where(delegate(int i)
            { 
                return i % 2 == 0; 
            });
            foreach (var item in a1) 
            { 
                Console.WriteLine(item); 
            }


            //real time example action

            List<string> names = new List<string>();
            names.Add("Roman");
            names.Add("John");
            names.Add("Seth");
            names.Add("Dean");
            //Traditional way
            Action<string> actionR;
            void Print(string s)
            {
                Console.WriteLine(s);
            } 
            actionR = Print;
            names.ForEach(actionR);
            //Using lambda expression

            names.ForEach(x => Console.WriteLine(x));

            //anonymous method

            names.ForEach(delegate (string name) 
            { Console.WriteLine(name); 
            });


            Console.ReadLine();
        }
    }
}
