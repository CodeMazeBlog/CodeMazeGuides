using System.Text.RegularExpressions;

namespace CountNumberOfVowelsInString
{
	public class VowelCountersHelperMethods
	{
        public static int CountVowelsUsingForLoop(string sentence, HashSet<char> vowels)
        {
            var total = 0;

            for (var i = 0; i < sentence.Length; i++)
            {
                if (vowels.Contains(sentence[i]))
                {
                    total++;
                }
            }

            Console.WriteLine($"The number of vowels counted using For loop is: {total}");

            return total;
        }

        public static int CountVowelsUsingForEachLoop(string sentence, HashSet<char> vowels)
        {
            var total = 0;

            foreach (var c in sentence)
            {
                if (vowels.Contains(c))
                {
                    total++;
                }
            }

            Console.WriteLine($"The number of vowels counted using ForEach loop is: {total}");

            return total;
        }

        public static int CountVowelsUsingSwitchStatement(string sentence)
        {
            var total = 0;

            foreach (var c in sentence)
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
                    default:
                        break;
                }

            }

            Console.WriteLine($"The number of vowels counted using Switch statement is: {total}");

            return total;
        }

        public static int CountVowelsUsingRegEx(string sentence)
        {
            var total = Regex.Matches(sentence, @"[AEIOU]", RegexOptions.IgnoreCase).Count;

            Console.WriteLine($"The number of vowels counted using RegEx is: {total}");

            return total;
        }

        public static int CountVowelsUsingStrReplaceAndLength(string sentence)
        {
            var rxVowels = new Regex(@"[^AEIOU]+", RegexOptions.IgnoreCase);

            var total = rxVowels.Replace(sentence, "").Length;

            Console.WriteLine($"The number of vowels counted using String Replace and String Join is: {total}");

            return total;
        }

        public static int CountVowelsUsingLinq(string sentence, HashSet<char> vowels)
        {
            var total = sentence.Count(x => vowels.Contains(x));

            Console.WriteLine($"The number of vowels counted using LINQ is: {total}");

            return total;
        }
    }
}

