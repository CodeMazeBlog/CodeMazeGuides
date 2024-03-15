namespace SplitString
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n***************** Split the String Using Character Array ***************\n");
            SplitStringUsingCharacterArray("apple,banana,cherry;date", new[] { ',', ';'});

            Console.WriteLine("\n***************** Split the String Using Character Array with String Split Options ***************\n");
            SplitStringUsingCharacterArrayWithoptions("John & Jane & James", new[] { ' ', '&' });

            Console.WriteLine("\n***************** Split the String Using Character Array Using Count ***************\n");
            SplitStringUsingCharacterArrayUsingCount("apple,banana,cherry,orange", new[] { ',' }, 3);

            Console.WriteLine("\n***************** Split the String Using Character Array with Options Using Count ***************\n");
            SplitStringUsingCharacterArrayWithoptionsUsingCount(" apple , banana ; cherry,orange ", new[] { ',', ';' }, 3);

            Console.WriteLine("\n***************** Split the String Using String Array with String Split Options ***************\n");
            SplitStringUsingStringArrayWithoptions("apple,banana,kiwi;grape,mango,orange", new[] { ",", ";" });

            Console.WriteLine("\n***************** Split the String Using String Array with String Split Options Using Count ***************\n");
            SplitStringUsingStringArrayWithoptionsUsingCount("apple,banana,cherry,orange,pear", new[] { "," }, 3);

            Console.WriteLine("\n***************** Split a String Into New Lines ***************\n");
            SplitStringIntoNewLines("Line 1\nLine 2\nLine 3\nLine 4\nLine 5", new[] { Environment.NewLine });
        }

        public static string[] SplitStringUsingCharacterArray(string input, char[] separators)
        {
            string[] result = input.Split(separators);

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

            return result;
        }

        public static string[] SplitStringUsingCharacterArrayWithoptions(string input, char[] separators)
        {
            string[] words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                Console.WriteLine(word);
            }
            return words;
        }

        public static string[] SplitStringUsingCharacterArrayUsingCount(string input, char[] separators, int limit)
        {
            string[] result = input.Split(separators, limit);

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            return result;
        }

        public static string[] SplitStringUsingCharacterArrayWithoptionsUsingCount(string input, char[] separators, int count)
        {
            string[] result = input.Split(separators, count, StringSplitOptions.TrimEntries);

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            return result;
        }

        public static string[] SplitStringUsingStringArrayWithoptions(string input, string[] delimiters)
        {
            string[] result = input.Split(delimiters, StringSplitOptions.None);

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            return result;
        }

        public static string[] SplitStringUsingStringArrayWithoptionsUsingCount(string input, string[] separators, int count)
        {
            string[] result = input.Split(separators, count, StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in result)
            {
                Console.WriteLine(s.Trim());
            }

            return result;
        }

        public static string[] SplitStringIntoNewLines(string multiLineText, string[] separators)
        {
            string[] lines = multiLineText.Split(separators, StringSplitOptions.None);

            foreach (string line in lines) 
            { 
                Console.WriteLine(line); 
            }

            return lines;
        }
    }
}