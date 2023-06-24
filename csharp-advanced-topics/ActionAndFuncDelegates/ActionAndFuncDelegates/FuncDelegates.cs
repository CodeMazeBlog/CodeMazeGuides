using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionAndFuncDelegatesDemo
{
    public sealed class FuncDelegates
    {
        public string Substring { get; set; }
        public string[] Arr { get; set; }
        public List<string> results { get; set; }
        public bool IsValidInputFlag { get; set; }
        public string? Message { get; set; }
        public FuncDelegates(string[] input, string substring)
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
 
        //Func delegate invoke parameterless method
        public void FuncDelegateWithParameterlessMethod()
        {
            // Func delegate invoke parameterless method
            Func<string> FuncWithParameterlessMethod = PrintMessageOnConsole;
            string temp = FuncWithParameterlessMethod();
            Console.WriteLine(temp);
        }

        // Func delegate invoke parameterized method
        public void FuncDelegateWithParameterizedMethod()
        {
            if (!IsValidInputFlag)
            {
                Message = "Input Error!!";
                Console.WriteLine(Message);
                return;
            }
            Func<string[], string, List<string>> FuncWithParameterizedMethod = ParameterizedMethod;
            results = new List<string>();
            results = FuncWithParameterizedMethod(Arr, Substring);            
            Console.WriteLine(string.Join("\n", results) + "\n");

        }

        //Func delegate invoke Anonymous method
        public void FuncDelegateWithAnonymousMethod()
        {
            if (!IsValidInputFlag)
            {
                Message = "Input Error!!";
                Console.WriteLine(Message);
                return;
            }
            Func<string[], string, List<string>> FuncWithAnonMethod = delegate (string[] list, string substring)
            {
                List<string> filteredList = list.Select(i => i.ToString())
                        .Where(i => i.ToLower().Contains(substring)).ToList();
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Func with Anonymous method:");
                return filteredList;
            };
            results = new List<string>();
            results = FuncWithAnonMethod(Arr, Substring);
            Console.WriteLine(string.Join("\n", results) + "\n");
        }

        // Func delegate invoke Lambda expression 
        public void FuncDelegateWithLambdaExpression()
        {
            if (!IsValidInputFlag)
            {
                Message = "Input Error!!";
                Console.WriteLine(Message);
                return;
            }
            Func<string[], string, List<string>> FuncWithLambdaExp = (string[] list, string substring) =>
            {
                List<string> filteredList = list.Select(i => i.ToString())
            .Where(i => i.ToLower().Contains(substring)).ToList();
                Console.WriteLine("Print all the elements containing substring '" + substring + "' using Func with lambda expression:");
                return filteredList;
            };
            results = new List<string>();
            results = FuncWithLambdaExp(Arr, Substring);
            Console.WriteLine(string.Join("\n", results) + "\n");
        }

        public string PrintMessageOnConsole()
        {
            return "Func Delegate invoked a parameterless method called. \n";
        }

        public List<string> ParameterizedMethod(string[] list, string substring)
        {
            Console.WriteLine("Print all the elements containing substring '" + substring + "' using Func with parameterized method:");
            List<string> filteredList = list.Select(i => i.ToString())
            .Where(i => i.ToLower().Contains(substring)).ToList();

            return filteredList;
        }
    }
}
