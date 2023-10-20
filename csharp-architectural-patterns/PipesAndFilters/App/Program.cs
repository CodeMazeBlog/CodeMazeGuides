// See https://aka.ms/new-console-template for more information

using App.Application;

Console.WriteLine(new SentimentAnalyzerPipe().Analyze("I am happy"));
Console.WriteLine(new SentimentAnalyzerPipe().Analyze("I am sad"));