using System.Collections.Generic;
using ActionAndFuncDelegates.Entities;

namespace ActionAndFuncDelegates.Extensions
{
    public static class UserExtension
    {
        public static void ExecutePrint(this IEnumerable<User> users, ExampleDelegates.PrintUserDataDelegate printMethod)
        {
            foreach (var user in users)
            {
                printMethod(user);
            }
        }
    }
}