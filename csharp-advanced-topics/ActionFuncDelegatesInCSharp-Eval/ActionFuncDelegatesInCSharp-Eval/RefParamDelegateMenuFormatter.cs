using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFuncDelegatesCSharp
{
    public class RefParamDelegateMenuFormatter : MenuFormatterBase
    {
        public delegate void FormatTitleDelegate(ref string title);
        public FormatTitleDelegate FormatTitle;
        public RefParamDelegateMenuFormatter(FormatTitleDelegate titleFormatter)
        {
            FormatTitle = titleFormatter;
        }

        public override string GetTitle(string titleText)
        {
            FormatTitle?.Invoke(ref titleText);
            Title = titleText;
            return Title;
        }
    }
}
