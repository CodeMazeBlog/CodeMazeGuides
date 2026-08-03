namespace Tests;

public class SentimentTest
{
    [Fact]
    public void WhenTextIsPositive_ThenSentimentIsPositive()
    {
        var result = SentimentAnalyzerPipe.Analyze("I love this product");
        Assert.Equal("Positive", result);
    }

    [Fact]
    public void WhenTextIsNegative_ThenSentimentIsNegative()
    {
        var result = SentimentAnalyzerPipe.Analyze("I hate this product");
        Assert.Equal("Negative", result);
    }

    [Fact]
    public void WhenTextIsNeutral_ThenSentimentIsNeutral()
    {
        var result = SentimentAnalyzerPipe.Analyze("I am neutral about this product");
        Assert.Equal("Neutral", result);
    }
}
