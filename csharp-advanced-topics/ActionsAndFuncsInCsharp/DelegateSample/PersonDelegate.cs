using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncsInCsharp.DelegateSample
{
    public class PersonDelegate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public delegate string customFullNameConstructor(string firstName, string lastName);

        public string ConstructFullName(customFullNameConstructor nameConstructor)
        {
            return nameConstructor(FirstName, LastName);
        }
    }
}
