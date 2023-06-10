using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncAndActionDelegatesInCSharp
{
    public class DelegateUseCases
    {
        public static void DelegatesDataTransformation()
        {
            var values = new List<string>
            {
                "code maze",
                "c#",
                "delegates"
            };
            Func<string, string> capitalize = (value) => value.ToUpper();
            var capitalizedValues = values.Select(capitalize).ToList(); //Result: {"CODE MAZE", "C#", "DELEGATES"}
            capitalizedValues.ForEach(Console.WriteLine);
        }

        public static void DelegatesConditionalFiltering()
        {
            var values = new List<string>
            {
                "this string contains Code Maze",
                "this string does not!",
            };
            Func<string, bool> containsCodeMaze = (value) => value.Contains("Code Maze");
            var stringsWithCodeMaze = values.Where(containsCodeMaze).ToList(); //Result: {""this string contains Code Maze"}
            stringsWithCodeMaze.ForEach(Console.WriteLine);
        }

        public static void DelegatesCallback()
        {
            static void Callback(string value)
            {
                Console.WriteLine($"Callback invoked with value: {value}");
            }
            static void ProcessEvent(string initailValue, Action<string> callback)
            {
                var newValue = $"{initailValue} Maze";
                callback(newValue);
            }
            ProcessEvent("Code", Callback); //Output: Callback invoked with value: Code Maze
        }
    }
}
