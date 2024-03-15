namespace App.Domain;

public static class SentimentAnalyzerPipe
{
    public static string Analyze(string text)
    {
        IFilter[] sentimentPipeLine = { new LowerCaseFilter(), new RemoveStopWordsFilter(), new SentimentFilter() };
        
        return sentimentPipeLine.Aggregate(text, (current, filter) => filter.Process(current));
    }
}