using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncsInCsharp.ActionSample
{
    public class NameLoggingLibrary
    {
        public static void LogInDatabase(string firstName, string lastName)
        {
            Console.WriteLine("This method writes the given info in a database file.");
        }

        public static void LogInFile(string firstName, string lastName)
        {
            Console.WriteLine("This method writes the given info in a plain text file.");
        }
    }
}
