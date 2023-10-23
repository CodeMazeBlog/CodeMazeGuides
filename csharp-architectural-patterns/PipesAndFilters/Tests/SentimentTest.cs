using App.Domain;

namespace Tests;

public class SentimentTest
{
    [Fact]
    public void WhenTextIsPositive_ThenSentimentIsPositive()
    {
        var bot = new SentimentAnalyzerPipe();
        var result = bot.Analyze("I love this product");
        Assert.Equal("Positive", result);
    }

    [Fact]
    public void WhenTextIsNegative_ThenSentimentIsNegative()
    {
        var bot = new SentimentAnalyzerPipe();
        var result = bot.Analyze("I hate this product");
        Assert.Equal("Negative", result);
    }

    [Fact]
    public void WhenTextIsNeutral_ThenSentimentIsNeutral()
    {
        var bot = new SentimentAnalyzerPipe();
        var result = bot.Analyze("I am neutral about this product");
        Assert.Equal("Neutral", result);
    }
}