using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharp
{
    public abstract class MenuFormatterBase<T>
    {
        public string Title { get; set; }
        public abstract string GetTitle(T titleContainer);
    }
    public abstract class MenuFormatterBase : MenuFormatterBase<string>
    {
    }
}
