using FindAllPositionsOfAString;

namespace Tests;

[TestClass]
public class JuliusCaesarTextTest
{
    [TestMethod]
    public void GivenJuliusCaesarText_WhenReading_ThenTextShouldNotBeEmpty()
    {
        var text = JuliusCaesarText.Read();

        Assert.IsFalse(string.IsNullOrEmpty(text));
    }

    [TestMethod]
    public void GivenJuliusCaesarText_WhenReading_ThenTextShouldNotHaveDoubleSpaces()
    {
        var text = JuliusCaesarText.Read();

        Assert.IsFalse(text.Contains("  "));
    }

    [TestMethod]
    public void GivenJuliusCaesarText_WhenReading_ThenTextShouldShouldHaveOnlyOneLine()
    {
        var text = JuliusCaesarText.Read();

        Assert.IsFalse(text.Contains('\n'));
    }

    [TestMethod]
    public void GivenJuliusCaesarText_WhenReading_ThenTextShouldContainOnlyLettersAndDigits()
    {
        var text = JuliusCaesarText.Read();

        Assert.IsTrue(text.All(c => char.IsLetterOrDigit(c) || c == ' '));
    }

    [TestMethod]
    public void GivenJuliusCaesarText_WhenReading_ThenWordsShouldBeIncluded()
    {
        var text = JuliusCaesarText.Read();
        var content = "Strato Countrymen My heart doth joy that yet in all my life I found no man";

        Assert.IsTrue(text.Contains(content));
    }
}
