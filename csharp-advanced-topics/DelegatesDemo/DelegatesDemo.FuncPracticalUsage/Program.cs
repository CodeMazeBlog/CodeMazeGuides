using System;
using System.Collections.Generic;

namespace DelegatesDemo.FuncPracticalUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> storage = new();
            storage.Add(1, "Jonn");
            storage.Add(2, "Kara");
            storage.Add(3, "Winn");
            storage.Add(4, "James");

            Console.WriteLine("Enter key:");
            var key = Convert.ToInt32(Console.ReadLine());

            var retriveFunc = new Func<string>(() =>
            {
                var name = storage[key];
                return name;
            });

            try
            {
                var nameFromStorage = RetryHelper.RetryOnException(retriveFunc, 3, TimeSpan.FromSeconds(5));
                Console.WriteLine(nameFromStorage);
                Console.ReadKey();
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
