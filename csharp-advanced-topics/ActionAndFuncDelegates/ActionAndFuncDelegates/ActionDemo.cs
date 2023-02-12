namespace ActionAndFuncDelegates;

public class ActionsDemo
{
    private readonly List<string> _sentenceWords;

    public ActionsDemo(string sentence)
    {
        _sentenceWords = sentence.Split(" ").ToList();
    }

    private void ProcessWords(Action<string> process)
    {
        foreach (var word in _sentenceWords)
        {
            process(word);
        }
    }

    public void WordsLengths()
    {
        ProcessWords(w => Console.WriteLine($"Word '{w}': {w.Length}"));
    }

    public void WordsLetterLocations(char letter)
    {
        ProcessWords(w => Console.WriteLine($"Word '{w}': {w.IndexOf(letter)}"));
    }

    public void WordsHashCodes()
    {
        ProcessWords(w => Console.WriteLine($"Word '{w}': {w.GetHashCode()}"));
    }
}