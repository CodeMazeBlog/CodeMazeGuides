using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncsInCsharp.ActionSample
{
    public class PersonAction
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void LogFullName(Action<string, string> nameLogger)
        {
            nameLogger(FirstName, LastName);
        }
    }
}
