// See https://aka.ms/new-console-template for more information

using App.Domain;

Console.WriteLine(new SentimentAnalyzerPipe().Analyze("I am happy"));
Console.WriteLine(new SentimentAnalyzerPipe().Analyze("I am sad"));