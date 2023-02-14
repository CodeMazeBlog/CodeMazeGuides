using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ActionAndFuncDelegatesTests;

public class TestFuncs : TestDelegates
{
    private FuncsDemo _funcsDemo;
    
    [SetUp]
    public void Setup()
    {
        SetupOutput();
        _funcsDemo = new FuncsDemo(SentenceHolder.Sentence);
    }

    [TearDown]
    public void TearDown()
    {
        DisposeOutput();
    }

    [Test]
    public void WhenDemoWordsLengths_ThenPrintsWordsLength()
    {
        // Act
        _funcsDemo.WordsLengths();

        // Assert
        var equalityArray = PrintedOutputToArray();
        Assert.That(equalityArray[0], Is.EqualTo("Word 'This': 4"));
    }
    
    [Test]
    public void WhenDemoWordsLetterLocationsA_ThenPrintsArticle1()
    {
        // Act
        _funcsDemo.WordsLetterLocations('a');

        // Assert
        var equalityArray = PrintedOutputToArray();
        Assert.Multiple(() =>
        {
            Assert.That(equalityArray[0], Is.EqualTo("Word 'This': -1"));
            Assert.That(equalityArray[1], Is.EqualTo("Word 'article': 0"));
        });
    }

    [Test]
    public void WhenDemoWordsHashCodes_ThenPrintsCorrectHashCode()
    {
        // Act
        _funcsDemo.WordsHashCodes();

        // Assert
        var equalityArray = PrintedOutputToArray();
        Assert.Multiple(() =>
        {
            Assert.That(equalityArray[0].StartsWith("Word 'This': "));
            Assert.That(int.TryParse(equalityArray[0].Split(" ")[2], out var hashCode));
            Assert.That(hashCode, Is.Not.EqualTo(0));
        });
    }
}