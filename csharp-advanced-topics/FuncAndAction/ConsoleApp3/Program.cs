using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static List<string> FoundWords;
        static void Main(string[] args)
        {
            var numbers = new List<int>() { -2, 1, 0, 3, -22, 10 };
            var filteringFunc = new Func<int, bool>(FilteringMethod);
            var anonymousFilteringFunc = new Func<int, bool>(n => n > 0);
            var positiveNumbers = numbers.Where(filteringFunc);
            foreach (var number in positiveNumbers)
                Console.WriteLine(number);
            positiveNumbers = numbers.Where(filteringFunc);
        }

        public static bool FilteringMethod(int n)
        {
            return n > 0;
        }



        public static ulong[] productFib(ulong prod)
        {
            ulong num1 = 0;
            ulong num2 = 1;
            bool isFound = false;
            bool cantBeFound = false;
            while (!isFound || !cantBeFound)
            {
                var temp = num2;
                num2 = num1 + temp;
                num1 = temp;
                if (prod == num1 * num2)
                    isFound = true;
                if (prod < num1 * num2)
                    cantBeFound = true;

            }
            return new ulong[3] { num1, num2, isFound ? (ulong)1 : (ulong)0 };
        }

        static string HHH(string[] strArr)
        {
            FoundWords = new List<string>();
            var matrixStrings = strArr[0].Split(", ");
            var matrix = new string[4, 4];
            for (int i = 0; i < 4; i++)
            {
                var temp = matrixStrings[i];
                for (int j = 0; j < temp.Length; j++)
                {
                    matrix[i, j] = temp[j].ToString();
                }
            }

            var words = strArr[1].Split(',');
            bool[,] visited = new bool[4, 4];
            var unFoundWords = new List<string>();

            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    findWords(matrix, visited, i, j, "", words);
            

            if (unFoundWords.Count > 0)
                return String.Join(',', unFoundWords);
            return "true";

        }

        
        static bool isWord(string str, string[] words)
        {
            // Linearly search all words
            for (int i = 0; i < words.Length; i++)
                if (str.Equals(words[i]))
                    return true;
            return false;
        }

        static void findWords(string[,] matrix, bool[,] visited, int i, int j, string str, string[] words)
        {
            visited[i, j] = true;
            str = str + matrix[i, j];

            if (isWord(str, words))
                FoundWords.Add(str);

            for (int row = i - 1; row <= i + 1 && row < 4; row++)
                for (int col = j - 1; col <= j + 1 && col < 4; col++)
                    if (row >= 0 && col >= 0 && !visited[row, col])
                        findWords(matrix, visited, row, col, str, words);
            str = "" + str[str.Length - 1];
            visited[i, j] = false;
        }

        public static Tuple<int, int> CoordinatesOf(string[,] matrix, string value)
        {
            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(value))
                        return Tuple.Create(x, y);
                }
            }

            return Tuple.Create(-1, -1);
        }

       

        private static string Reverse(string str)
        {
            char[] array = str.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        private static List<string> GeneratePossibleWords(string[,] matrix, char ch)
        {
            var result = new List<string>();
            for(var i = 0; i < 4; i++)
            {
                for(var j = 0; j < 4; j++)
                {
                    try
                    {
                        result.Add(matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]);
                        result.Add(matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2] + matrix[i, j + 3]);
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                    try
                    {
                        result.Add(matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j]);
                        result.Add(matrix[i, j] + matrix[i + 1, j] + matrix[i + 2, j] + matrix[i + 3, j]);
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                    try
                    {
                        result.Add(matrix[i, j] + matrix[i + 1, j + 1] + matrix[i + 2, j + 2]);
                        result.Add(matrix[i, j] + matrix[i + 1, j + 1] + matrix[i + 2, j + 2] + matrix[i + 2, j + 3]);
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                }
            }
            return result;
        }

       

        static string FF(string s)
        {
            var openTags = new string[5] {
                "<b>",
                "<i>",
                "<em>",
                "<div>",
                "<p>"
            };

            var closingTags = new string[5] {
                "</b>",
                "</i>",
                "</em>",
                "</div>",
                "</p>"
            };

            var stack = new Stack<string>();

            var tags = Regex.Split(s, "(<[^>]*>)");

            foreach (var tag in tags)
            {
                if (openTags.Contains(tag))
                {
                    stack.Push(tag);
                }
                else if (closingTags.Contains(tag))
                {
                    var closingTagIndex = Array.IndexOf(closingTags, tag);
                    if (stack.Count > 0 && (openTags[closingTagIndex] == stack.Peek()))
                        stack.Pop();
                }

                if (stack.Count > 0)
                    return "true";
                else
                    return stack.Peek().Replace("<", "").Replace(">", "");

            }

            return "";
        }


        static void _printParenthesis(char[] str,
            int pos, int n, int open, int close)
        {
            if (close == n)
            {
                // print the possible combinations
                for (int i = 0; i < str.Length; i++)
                    Console.Write(str[i]);

                Console.WriteLine();
                return;
            }
            else
            {
                if (open > close)
                {
                    str[pos] = '}';
                    _printParenthesis(str, pos + 1,
                                    n, open, close + 1);
                }
                if (open < n)
                {
                    str[pos] = '{';
                    _printParenthesis(str, pos + 1,
                                    n, open + 1, close);
                }
            }
        }

        // Wrapper over _printParenthesis()
        static void printParenthesis(char[] str, int n)
        {
            if (n > 0)
                _printParenthesis(str, 0, n, 0, 0);
            return;
        }



        static string[] increasingSubstrings(string s)
        {
            var alphapet = "abcdefghijklmnopqrstuvwxyz";
            var capitalAlphapet = alphapet.ToUpper();

            var result = new List<string>();
            var r = new int[5];
            string.Join(',', r);
            for (var i = 0; i < s.Length; i++)
            {
                string sub = "";
                if (s.Length < i + 2)
                    result.Add(s[i].ToString());
                
                for(var j = i + 1; j < s.Length; j++)
                {
                    sub = s.Substring(i, j - i + 1);
                    if(!alphapet.Contains(sub) && !capitalAlphapet.Contains(sub))
                    {
                        i = j - 1;
                        result.Add(sub.Substring(0, sub.Length - 1));
                        break;
                    }
                    if ((j + 1 == s.Length))
                    {
                        result.Add(sub);
                        return result.ToArray();
                    }
                }
                
            }

            return result.ToArray();

        }



        static string palindromeCutting(string s)
        {
            var max = 0;
            int start = 0;
            int end = 0;
            var result = s;
            for (var i = 1; i < s.Length; i++)
            {
                var prefix = s.Substring(0, i + 1);
                if (isPalindrome(prefix))
                {
                    if (prefix.Length > max)
                    {
                        max = prefix.Length;
                        start = 0;
                        end = i + 1;
                    }
                   
                }
                else if(max > 0)
                {
                    s = palindromeCutting(s.Remove(start, end));
                }
            }
            if(s.Length > 2 && max > 0)
                s = palindromeCutting(s.Remove(start, end));

            return s;

        }

        static bool isPalindrome(string s)
        {
            return s == stringReverseString(s);
        }

        static string stringReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            char[] result = new char[chars.Length];
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                result[i] = chars[j];
            }
            return new string(result);
        }
    }

    class Fruit
    {
        protected string Color;
    }

    class Orange: Fruit
    {
        public Orange()
        {
            Color = "ss";
        }
    }
}
