using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace delegatesExample
{
    public partial class FuncDelegatesTest : System.Web.UI.Page
    {
        delegate string ConvertMethod(string inString);

        protected void Page_Load(object sender, EventArgs e)
        {
            Func<int,int,int> Addition = AddNumbers;  
            int result = Addition(10, 20);  
            lbl1.Text =  "Addition ="+ result;  

            ConvertMethod convertMeth = UppercaseString;
            string name = "Nidhi Shukla";
            // Use delegate instance to call UppercaseString method
            lbl2.Text = convertMeth(name);
        }
        private static int AddNumbers(int param1, int param2)
        {
            return param1 + param2;
        }  
        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }
    }
}