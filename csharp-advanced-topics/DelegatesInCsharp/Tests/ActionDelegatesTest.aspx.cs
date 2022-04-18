using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace delegatesExample
{
    public partial class ActionDelegatesTest : System.Web.UI.Page
    {
        delegate void ConvertMethod(string inString);
        private static int result;
        private static string uppername;  
        protected void Page_Load(object sender, EventArgs e)
        {
            Action<int,int> Addition = AddNumbers;  
            Addition(10, 20);  
            lbl1.Text =  "Addition ="+ result;  

            ConvertMethod convertMeth = UppercaseString;
            string name = "Nidhi Shukla";
            // Use delegate instance to call UppercaseString method
             convertMeth(name);
             lbl2.Text = "Name =" + uppername;
        }
        private static void AddNumbers(int param1, int param2)
        {
            result = param1 + param2;
        }
        private static void UppercaseString(string inputString)
        {

            uppername = inputString.ToUpper();
        }
    }
}