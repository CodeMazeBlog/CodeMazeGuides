using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func_Action_Delegate_Library.Action
{
    public class ActionWithLambdaExpression
    {
        public List<string> Names = new List<string> { "John", "Milo", "Rambo", "Joseph" };
        public string ToFind { set; get; }
        public bool IsFound { set; get; }
        public Action<string> IsNameExist;
    }
}
