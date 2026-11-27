using System.Globalization;
using StringToTitleCase;

namespace StringToTitleCaseUnitTest;

[TestClass]
public class StringToTitleCaseUnitTest
{
    private readonly TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

    [TestMethod]
    public void GivenToTitleCase_WhenStringIsPassed_ConversionToTitleCaseSuccessful()
    {
        Assert.AreEqual("A Tale Of Two Cities", textInfo.ToTitleCase("a tale oF tWo citIes"));

        Assert.AreEqual("Harry Potter And The Deathly Hallows", textInfo.ToTitleCase("harry potter and the Deathly hallows"));
    }

    [TestMethod]
    public void GivenToTitleCase_WhenWordWithAllUpperCaseIsPassed_ConversionToTitleCaseNotSuccessful()
    {
        Assert.AreEqual("OLIVER TWIST", textInfo.ToTitleCase("OLIVER TWIST"));
    }

    [TestMethod]
    public void GivenToTitleCase_WhenWordWithAllUpperCaseIsPassed_ConversionToTitleCaseSuccessful()
    {
        Assert.AreEqual("Oliver Twist", textInfo.ToTitleCase(textInfo.ToLower("OLIVER TWIST")));
    }

    [TestMethod]
    public void GivenToTitleCase_WhenAcronymIsLowercasedFirst_AcronymIsLost()
    {
        Assert.AreEqual("The NASA Mission", textInfo.ToTitleCase("the NASA mission"));

        Assert.AreEqual("The Nasa Mission", textInfo.ToTitleCase(textInfo.ToLower("THE NASA MISSION")));
    }

    [TestMethod]
    public void GivenCurrentCultureIsTurkish_WhenStringToLowerIsUsed_DotlessIAppears()
    {
        var original = CultureInfo.CurrentCulture;
        try
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");

            Assert.AreEqual("Olıver Twıst", textInfo.ToTitleCase("OLIVER TWIST".ToLower()));
            Assert.AreEqual("Oliver Twist", textInfo.ToTitleCase(textInfo.ToLower("OLIVER TWIST")));
        }
        finally
        {
            CultureInfo.CurrentCulture = original;
        }
    }

    [TestMethod]
    public void GivenToTitleCaseWithMinorWords_WhenStringIsPassed_MinorWordsStayLowercase()
    {
        Assert.AreEqual("A Tale of Two Cities", "a tale oF tWo citIes".ToTitleCaseWithMinorWords(textInfo));

        Assert.AreEqual("Harry Potter and the Deathly Hallows", "harry potter and the Deathly hallows".ToTitleCaseWithMinorWords(textInfo));

        Assert.AreEqual("The Lord of the Rings", "the lord of the rings".ToTitleCaseWithMinorWords(textInfo));
    }

    [TestMethod]
    public void GivenToTitleCase_WhenCultureIsTurkish_ResultUsesTurkishCasing()
    {
        var turkish = new CultureInfo("tr-TR", false).TextInfo;

        Assert.AreEqual("A Tale Of Two Citıes", turkish.ToTitleCase("a tale oF tWo citIes"));
        Assert.AreEqual("İstanbul", turkish.ToTitleCase("istanbul"));
        Assert.AreEqual("A Tale Of Two Cities", CultureInfo.InvariantCulture.TextInfo.ToTitleCase("a tale oF tWo citIes"));
    }

    [TestMethod]
    public void GivenToTitleCase_WhenWordHasDigitsOrInnerCapitals_ResultIsNotWhatAHumanWrites()
    {
        Assert.AreEqual("The 2Nd Edition", textInfo.ToTitleCase("the 2nd edition"));
        Assert.AreEqual("My Iphone", textInfo.ToTitleCase("my iPhone"));
        Assert.AreEqual("Mcdonald's Menu", textInfo.ToTitleCase("mcdonald's menu"));
        Assert.AreEqual("X-Ray Vision", textInfo.ToTitleCase("x-ray vision"));
    }
}
