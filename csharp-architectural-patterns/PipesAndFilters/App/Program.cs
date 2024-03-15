using App.Domain;

var positiveSentiment = SentimentAnalyzerPipe.Analyze("I am happy");
var negativeSentiment = SentimentAnalyzerPipe.Analyze("I am sad");
var neutralSentiment = SentimentAnalyzerPipe.Analyze("I am ok");

Console.WriteLine($"Positive sentiment: {positiveSentiment}");
Console.WriteLine($"Negative sentiment: {negativeSentiment}");
Console.WriteLine($"Neutral sentiment: {neutralSentiment}");
