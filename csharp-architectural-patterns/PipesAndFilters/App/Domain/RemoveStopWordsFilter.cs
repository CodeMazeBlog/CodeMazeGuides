namespace App.Domain;

public class RemoveStopWordsFilter : IFilter
{
    private static readonly HashSet<string> StopWords = new()
    {
        "a", "an", "and", "are", "as", "at", "be", "but", "by", "my", "not", "of", "on", "or", "the", "to"
    };

    public string Process(string input)
    {
        var words = input.Split(new[] { " ", "\t", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
        var filterWords = words.Where(x => !StopWords.Contains(x));
        
        return string.Join(" ", filterWords);
    }
}