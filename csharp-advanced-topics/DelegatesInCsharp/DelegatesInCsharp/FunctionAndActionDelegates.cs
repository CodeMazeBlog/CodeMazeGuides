using System;

namespace DelegatesInCsharp
{


    public class FunctionAndActionDelegates 
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                "Inline Code Solution: " +
                GetFormattedInputUsingInlineCode(args[0])
            );

            Console.WriteLine(
                "Delegate Code Solution: " +
                GetFormattedInputUsingDelegateCode(args[0])
            );

            Console.WriteLine(
                "BONUS - Composable Delegate Code Solution: " +
                GetFormattedInputUsingDelegateCode(
                    args[0], 
                    IsFormatted, 
                    FormatInput, 
                    Log
                )
            );
        }

        public static string GetFormattedInputUsingInlineCode(string input) 
        { 
            Console.WriteLine(input); 
            
            if (input.StartsWith("[Pretty]") && input.Contains($"{DateTime.Now.Year}")) 
            { 
                return input; 
            } 
            
            var formattedInput = $"[Pretty] {DateTime.Now.Year}: {input}"; 
            
            Console.WriteLine(formattedInput); 
            
            return formattedInput; 
        }

        public string GetFormattedInputUsingDelegateCode(string input) 
        { 
            Log(input); 
            
            if (IsFormatted(input)) 
            { 
                return input; 
            } 
            
            var formattedInput = FormatInput(input); 
            
            Log(formattedInput); 
            
            return formattedInput;     
        } 
        
        static Func<string, bool> IsFormatted 
            = (input) => input.StartsWith("[Pretty]") && input.Contains($"{DateTime.Now.Year}"); 
        
        static Func<string, string> FormatInput 
            = (input) => $"[Pretty] {DateTime.Now.Year}: {input}"; 
        
        static Action<string> Log 
            = (message) => Console.WriteLine(message);
        
        //============================= Bonus Composable Delegate Solution - START =============================

        public string GetFormattedInputUsingDelegateCode(
            string input, 
            Func<string, bool> isFormatted,
            Func<string, string> formatInput,
            Action<string> log
        ) 
        { 
            log(input); 
            
            if (isFormatted(input)) 
            { 
                return input; 
            } 
            
            var formattedInput = formatInput(input); 
            
            log(formattedInput); 
            
            return formattedInput;     
        } 

        //============================= Bonus Composable Delegate Solution - END =============================
    }
}