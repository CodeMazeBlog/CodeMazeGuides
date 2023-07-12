namespace ActionFuncDelegates;

internal class Program
{    
    public static void Main(string[] args)
    {
        //We instantiate the Site class
        SiteInfo siteInfo = new SiteInfo();

        // Our Action Delegate that takes an input and invokes it in the BestSite method in our SiteInfo Class
        Action<string> learnCSharp = siteInfo.BestSite;
        learnCSharp("CodeMaze");

        // Func delegate that takes 6 and 9 as our integers and sums them using the TotalArticles method in the SiteInfo Class
        Func<int, int, int> addArticles = siteInfo.TotalArticles;
        var result = addArticles(6, 9);
        Console.WriteLine("Total articles are: " + result);
    }
}
