using ActionAndFuncDelegates;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace ActionAndFuncDelegatesTests;

public class TestActions
{
    private StringWriter _output;
    
    [SetUp]
    public void Setup()
    {
        _output = new StringWriter();
        Console.SetOut(_output);
    }

    [TearDown]
    public void TearDown()
    {
        _output.Dispose();
        GC.SuppressFinalize(this);
    }

    private string[] PrintedOutputToArray()
    {
        var printedString = _output.ToString();
        return printedString.Split( Environment.NewLine );
    }

    [Test]
    public void WhenDemoWordsLengths_ThenPrintsWordsLength()
    {
        var actionDemo = new ActionsDemo(SentenceHolder.Sentence);
        actionDemo.WordsLengths();

        var equalityArray = PrintedOutputToArray();

        Assert.That(equalityArray[0], Is.EqualTo("Word 'This': 4"));
    }
    
    [Test]
    public void WhenDemoWordsLetterLocationsA_ThenPrintsArticle1()
    {
        var actionDemo = new ActionsDemo(SentenceHolder.Sentence);
        actionDemo.WordsLetterLocations('a');

        var equalityArray = PrintedOutputToArray();

        Assert.That(equalityArray[0], Is.EqualTo("Word 'This': -1"));
        Assert.That(equalityArray[1], Is.EqualTo("Word 'article': 0"));
    }
    
    [Test]
    public void WhenDemoWordsHashCodes_ThenPrintsCorrectHashCode()
    {
        var actionDemo = new ActionsDemo(SentenceHolder.Sentence);
        actionDemo.WordsHashCodes();

        var equalityArray = PrintedOutputToArray();

        Assert.That(equalityArray[0].StartsWith("Word 'This': "));
        Assert.That(int.TryParse(equalityArray[0].Split(" ")[2], out var hashCode));
        Assert.That(hashCode != 0);
    }
}