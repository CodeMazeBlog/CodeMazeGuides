namespace App.Domain;

public class SentimentAnalyzerPipe
{
    public string Analyze(string text)
    {
        IFilter[] sentimentPipeLine = { new LowerCaseFilter(), new RemoveStopWordsFilter(), new SentimentFilter() };
        return sentimentPipeLine.Aggregate(text, (current, filter) => filter.ProcessAsync(current));
    }
}