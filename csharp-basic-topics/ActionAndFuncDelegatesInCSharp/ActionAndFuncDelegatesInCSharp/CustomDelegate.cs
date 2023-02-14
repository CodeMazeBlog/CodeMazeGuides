using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesInCSharp.CustomDelegate
{
    public static class CustomDelegate
    {
        // Declaring the custom delegate
        public delegate string customDelegate(string[] delegateStrings);

        // Method
        public static string stringConnector(string[] methodStrings)
        {
            return string.Join(" ", methodStrings);
        }
        public static string GetValueFromCustomDelegate()
        {
            // Creating object of customDelegate
            customDelegate delegateObj = stringConnector;
            return delegateObj(new string[] { "I", "Love", "C#", "with Custom Delegates" });
        }
    }
}
