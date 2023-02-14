using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ActionAndFuncDelegatesTests;

public class TestActions : TestDelegates
{
    private ActionsDemo _actionDemo;
    
    [SetUp]
    public void Setup()
    {
        SetupOutput();
        _actionDemo = new ActionsDemo(SentenceHolder.Sentence);
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
        _actionDemo.WordsLengths();

        // Assert
        var equalityArray = PrintedOutputToArray();
        Assert.That(equalityArray[0], Is.EqualTo("Word 'This': 4"));
    }
    
    [Test]
    public void WhenDemoWordsLetterLocationsA_ThenPrintsArticle1()
    {
        // Act
        _actionDemo.WordsLetterLocations('a');

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
        _actionDemo.WordsHashCodes();

        // Assert
        var equalityArray = PrintedOutputToArray();
        Assert.Multiple(() =>
        {
            Assert.That(equalityArray[0].StartsWith("Word 'This': "));
            Assert.That(int.TryParse(equalityArray[0].Split(" ")[2], out var hashCode));
            Assert.That(hashCode != 0);
        });
    }
}