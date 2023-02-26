using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharp
{
    public class DelegateMenuFormatter : MenuFormatterBase
    {
        public delegate void FormatTitleDelegate(MenuFormatterBase menuFormatter);
        public FormatTitleDelegate FormatTitle;
        public DelegateMenuFormatter(FormatTitleDelegate titleFormatter)
        {
            FormatTitle = titleFormatter;
        }

        public override string GetTitle(string titleText)
        {
            Title = titleText;
            FormatTitle?.Invoke(this);
            return Title;
        }
    }
}
