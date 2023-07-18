using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Func_Delegates.ActionFuncDelegates;
//This is a method that takes a string and prints it in the console
public class SiteInfo
{
    //This is a method that takes a string and prints it in the console
    public void BestSite(string name)
    {
        Console.WriteLine("Howdy, welcome to " + name + " where learning is simplified.");
    }
    //This is a method that takes two integer and sums them
    public int TotalArticles(int angularArticles, int CSharpArticles)
    {
        return angularArticles + CSharpArticles;
    }
}
