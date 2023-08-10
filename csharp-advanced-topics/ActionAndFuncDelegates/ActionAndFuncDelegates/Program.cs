using System;
using System.Collections.Generic;
using ActionAndFuncDelegates.Entities;
using ActionAndFuncDelegates.Extensions;
using ActionAndFuncDelegates.IO;

namespace ActionAndFuncDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var exMethods = new ExampleMethods(new AppConsole());

            ExampleDelegates.PrintUserDataDelegate onPrintUserName = exMethods.PrintUserName;
            ExampleDelegates.PrintUserDataDelegate onPrintAllUserData = exMethods.PrintAllUserData;
            Action<User> onPrintDaysOld = exMethods.PrintUserDaysOfLife;
            Func<User, string> onPrintIfIsChildOrAdult = exMethods.PrintIfUserIsAdultOrChild;
            
            var users = new List<User>()
            {
                new() { Name = "Pablo", Age = 30 },
                new() { Name = "Theo", Age = 6 },
                new() { Name = "Matteo", Age = 3 }
            };

            Console.WriteLine("\tLet's see the usernames:");
            users.ExecutePrint(onPrintUserName);

            Console.WriteLine("\n\tLet's see the user's age:");
            users.ExecutePrint(onPrintAllUserData);

            Console.WriteLine("\n\tLet's see the user's age in days:");
            users.ForEach(onPrintDaysOld);

            Console.WriteLine("\n\tLet's see which users are adults or children:");
            foreach (var user in users)
            {
                Console.WriteLine(onPrintIfIsChildOrAdult(user));
            }
        }
    }
}
