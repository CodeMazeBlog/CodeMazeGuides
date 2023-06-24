using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesDemo
{
    public class ActionDelegates
    {
        public string Substring { get; set; }
        public string[] Arr { get; set; }
        public List<string> results { get; set; }
        public bool IsValidInputFlag { get; set; }
        public string? Message { get; set; }
        public ActionDelegates(string[] input, string substring)
        {
            Substring = substring;
            Arr = input;
            if (input != null && input.Length != 0 && !string.IsNullOrEmpty(substring))
            {
                results = new List<string>();
                IsValidInputFlag = true;
                Message = string.Empty;
            }
            else
            {
                IsValidInputFlag = false;
            }
        }
        public void ActionDelegateParameterlessMethod()
        {
            // Action Delegate encapsulating parameterless method 
            Action ActionWithParameterlessMethod = PrintMessageOnConsole;
            ActionWithParameterlessMethod();
        }

        public void ActionDelegateWithParameterizedMethod()
        {
            if (!IsValidInputFlag)
            {
                Message = "Input Error!!";
                Console.WriteLine(Message);
                return;
            }
            // Print all the elements containing substring using Action delegate encapsulating parameterized method
            Action<string[], string> ActionWithParameterizedMethod = ParameterizedMethod;
            ActionWithParameterizedMethod(Arr, Substring);
        }
        public void ActionDelegateWithAnonymousMethod()
        {
            if (!IsValidInputFlag)
            {
                Message = "Input Error!!";
                Console.WriteLine(Message);
                return;
            }
            // Print all the elements containing substring using Action delegate encapsulating Anonymous method
            Action<string[], string> ActionWithAnonymousMethod = delegate (string[] list, string substring)
            {
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Action with Anonymous method:");
                string[] filteredList = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring)).ToArray();
                Console.WriteLine(string.Join("\n", filteredList) + "\n");
                results = new List<string>();
                results.AddRange(filteredList);
            };
            ActionWithAnonymousMethod(Arr, Substring);
        }
        public void ActionDelegateWithLambdaExpression()
        {
            if (!IsValidInputFlag)
            {
                Message = "Input Error!!";
                Console.WriteLine(Message);
                return;
            }
            // Print all the elements containing substring using Action delegate encapsulating Lambda Expression
            Action<string[], string> ActionWithLambdaExp = (string[] list, string substring) =>
            {
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Action with Lambda Expression:");
                string[] filteredList = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring)).ToArray();
                Console.WriteLine(string.Join("\n", filteredList) + "\n");
                results = new List<string>();
                results.AddRange(filteredList);
            };
            ActionWithLambdaExp(Arr, Substring);
        }

        public static void PrintMessageOnConsole()
        {
            Console.WriteLine("Action Delegate invoked a parameterless method. \n");
        }

        public void ParameterizedMethod(string[] list, string substring)
        {
            if (list != null && list.Length != 0 && !string.IsNullOrEmpty(substring))
            {
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Action with parameterized method:");
                var filteredList = list.Select(i => i.ToString())
                .Where(i => i.ToLower().Contains(substring));
                Console.WriteLine(string.Join("\n", filteredList) + "\n");
                results = new List<string>();
                results.AddRange(filteredList);
            }
            else
            { Console.WriteLine("Incorrect input"); }
        }
    }
}
