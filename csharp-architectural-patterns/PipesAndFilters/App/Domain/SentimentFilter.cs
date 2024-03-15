namespace App.Domain;

public class SentimentFilter : IFilter
{
    public string Process(string input)
    {
        var positiveWords = new HashSet<string>
        {
            "good", "great", "awesome", "fantastic", "happy", "love", "like"
        };

        var negativeWords = new HashSet<string>
        {
            "bad", "terrible", "awful", "hate", "dislike", "sad"
        };

        var words = input.Split(new[] { " ", "\t", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
        var positiveCount = words.Count(x => positiveWords.Contains(x));
        var negativeCount = words.Count(x => negativeWords.Contains(x));

        if (positiveCount > negativeCount) return "Positive";
        
        return negativeCount > positiveCount ? "Negative" : "Neutral";
    }
}