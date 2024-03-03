using System.Text.RegularExpressions;

public class VowelCounters
{
    static void Main()
    {
        var vowels = new HashSet<char> { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };
        string sentence = "In the vast expanse of the universe, countless galaxies swirl in a cosmic dance, each telling a unique story of creation and destruction.";
        Console.WriteLine(sentence);

        CountVowelsWithForLoop(sentence, vowels);
        CountVowelsWithForEachLoop(sentence, vowels);
        CountVowelsUsingSwitchStatement(sentence);
        CountVowelsUsingRegEx(sentence);
        CountVowelsUsingStrReplaceAndLength(sentence);
        CountVowelsUsingLinq(sentence, vowels);
    }

    public static int CountVowelsWithForLoop(string sentence, HashSet<char> vowels)
    {
        int total = 0;

        for (int i = 0; i < sentence.Length; i++)
        {
            if (vowels.Contains(sentence[i]))
            {
                total++;
            }
        }

        Console.WriteLine($"The number of vowels counted using For loop is: {total}");

        return total;
    }

    public static int CountVowelsWithForEachLoop(string sentence, HashSet<char> vowels)
    {
        int total = 0;

        foreach (char c in sentence)
            if (vowels.Contains(c))
                total++;

        Console.WriteLine($"The number of vowels counted using ForEach loop is: {total}");

        return total;
    }

    public static int CountVowelsUsingSwitchStatement(string sentence)
    {
        int total = 0;
        foreach (char c in sentence)
        {
            switch (c)
            {
                case 'A':
                case 'a':
                case 'E':
                case 'e':
                case 'I':
                case 'i':
                case 'O':
                case 'o':
                case 'U':
                case 'u':
                    total++;
                    break;
                default: continue;
            }

        }
        Console.WriteLine($"The number of vowels counted using Switch statement is: {total}");

        return total;
    }

    public static int CountVowelsUsingRegEx(string sentence)
    {
        int total = Regex.Matches(sentence, @"[AEIOUaeiou]").Count;

        Console.WriteLine($"The number of vowels counted using RegEx is: {total}");

        return total;
    }

    public static int CountVowelsUsingStrReplaceAndLength(string sentence)
    {
        Regex rxVowels = new Regex(@"[^AEIOU]+", RegexOptions.IgnoreCase);
        int total = rxVowels.Replace(sentence, "").Length;

        Console.WriteLine($"The number of vowels counted using String Replace and String Join is: {total}");

        return total;
    }

    public static int CountVowelsUsingLinq(string sentence, HashSet<char> vowels)
    {
        int total = sentence.Count(x => vowels.Contains(x));

        Console.WriteLine($"The number of vowels counted using LINQ is: {total}");

        return total;
    }
}