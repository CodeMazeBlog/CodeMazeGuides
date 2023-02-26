using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharp
{
    public class FuncMenuFormatter : MenuFormatterBase
    {
        public Func<string, string> FormatTitle { get; set; }

        public override string GetTitle(string titleContainer)
        {
            return FormatTitle?.Invoke(titleContainer);
        }
    }
}
