using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharp
{
    public class ActionMenuFormatter : MenuFormatterBase
    {
        public Action<MenuFormatterBase> FormatTitle { get; set; }

        public override string GetTitle(string titleText)
        {
            Title = titleText;
            FormatTitle?.Invoke(this);
            return Title;
        }
    }
}
