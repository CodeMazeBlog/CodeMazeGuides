namespace ActionAndFuncDelegates;

public class FuncsDemo
{
    private readonly List<string> _sentenceWords;

    public FuncsDemo(string sentence)
    {
        _sentenceWords = sentence.Split(" ").ToList();
    }
    
    private void ProcessWords(Func<string, int> count)
    {
        foreach (var word in _sentenceWords)
        {
            Console.WriteLine($"Word '{word}': {count(word)}");
        }
    }

    public void WordsLengths()
    {
        ProcessWords(w => w.Length);
    }

    public void WordsLetterLocations(char letter)
    {
        ProcessWords(w => w.IndexOf(letter));
    }

    public void WordsHashCodes()
    {
        ProcessWords(w => w.GetHashCode());
    }
}