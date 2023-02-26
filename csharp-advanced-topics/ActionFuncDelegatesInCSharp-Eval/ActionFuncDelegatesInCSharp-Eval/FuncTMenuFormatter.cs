using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharp
{
    public class FuncTMenuFormatter<T> : MenuFormatterBase<T>
    {
        public Func<T, string> FormatTitle { get; set; }

        public override string GetTitle(T titleContainer)
        {
            return FormatTitle?.Invoke(titleContainer);
        }
    }
}
