using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncsInCsharp.DelegateSample
{
    public class NameConstructorLibrary
    {
        public static string NameFirst(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        public static string SurnameFirst(string firstName, string lastName)
        {
            return $"{lastName}, {firstName}";
        }
    }
}
