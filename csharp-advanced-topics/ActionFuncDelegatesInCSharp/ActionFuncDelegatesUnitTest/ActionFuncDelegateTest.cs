using ActionFuncDelegates;

namespace ActionFuncDelegatesUnitTest;

public class ActionFuncDelegateTest
{
    private SiteInfo _siteInfo;
    [SetUp]
    public void Setup()
    {
        _siteInfo = new SiteInfo();

    }

    [Test]
    public void BestSite_ShouldReturnSiteToLearnCSharp()
    {
        //We assign the expected Action delegate output and what we get
        var expected = "Howdy, welcome to CodeMaze where learning is simplified.";
        StringWriter stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        //Act on the Action delegate
        Action<string> learnCSharp = _siteInfo.BestSite;
        learnCSharp("CodeMaze");

        var result = stringWriter.ToString().Trim();

        //Assert that the result on the console is the same as what our delegate has
        Assert.AreEqual(expected, result);

    }
    [Test]
    public void TotalArticles_ShouldReturnTotalArticles()
    {
        //We assign an expected number of articles
        var expected = 15;

        //We act on the Func Delegate to add the number of articles
        Func<int, int, int> addArticles = _siteInfo.TotalArticles;
        var result = addArticles(6, 9);

        //We assert that the addition equates what we expected
        Assert.AreEqual(expected, result);
    }
}