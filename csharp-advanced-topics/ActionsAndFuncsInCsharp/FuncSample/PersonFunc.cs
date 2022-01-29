using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionsAndFuncsInCsharp.FuncSample
{
    public class PersonFunc
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ConstructFullName(Func<string, string, string> nameConstructor)
        {
            return nameConstructor(FirstName, LastName);
        }
    }
}
