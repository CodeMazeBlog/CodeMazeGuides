using System.Text.RegularExpressions;

namespace CheckIfStringArrayContainsAValueAndGetIndex
{
    public class CheckMethods
    {
        private readonly string[] _stringArray =
        {
            "dog", "horse", "emu", "lizard", "duck",
            "frog", "SNAKE", "emu", "duck", "GOOSE"
        };

        public int ForLoop()
        {
            string value = "horse";
            int index = -1;
            for (int i = 0; i < _stringArray.Length; i++)
            {
                if (_stringArray[i] == value)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        public int ForEachLoop()
        {
            string value = "dog";
            int index = -1;
            int step = 0;
            foreach (var item in _stringArray)
            {
                if (item == value)
                {
                    index = step;
                    break;
                }
                step++;
            }

            return index;
        }

        public int ArrayIndexOf()
        {
            string value = "lizard";
            int index = Array.IndexOf(_stringArray, value);

            return index;
        }

        public int ArrayFindIndex()
        {
            string value = "frog";
            int index = Array.FindIndex(_stringArray, str => str == value);

            return index;
        }

        public int ArrayCaseInsensitiveFindIndex()
        {
            string caseInsensitiveValue = "Snake";
            int index = Array.FindIndex(_stringArray, str => str.Equals(caseInsensitiveValue, StringComparison.OrdinalIgnoreCase));

            return index;
        }

        public int ArrayFindIndexWithContains()
        {
            string value = "du";
            int index = Array.FindIndex(_stringArray, str => str.Contains(value));

            return index;
        }

        public int ArrayFindIndexWithStartsWith()
        {
            string value = "liz";
            int index = Array.FindIndex(_stringArray, str => str.StartsWith(value));

            return index;
        }

        public int ArrayFindIndexWithEndsWith()
        {
            string value = "rse";
            int index = Array.FindIndex(_stringArray, str => str.EndsWith(value));

            return index;
        }

        public int ArrayFindIndexWithRegex()
        {
            string pattern = @"^(fro)";
            int index = Array.FindIndex(_stringArray, str => Regex.IsMatch(str, pattern));

            return index;
        }

        public int ArrayLastIndexOf()
        {
            string value = "duck";
            int index = Array.LastIndexOf(_stringArray, value);

            return index;
        }

        public int ArrayFindLastIndex()
        {
            string value = "emu";
            int index = Array.FindLastIndex(_stringArray, str => str == value);

            return index;
        }

        public int ArrayCaseInsensitiveFindLastIndex()
        {
            string caseInsensitiveValue = "Goose";
            int index = Array.FindLastIndex(_stringArray, str => str.Equals(caseInsensitiveValue, StringComparison.OrdinalIgnoreCase));

            return index;
        }
    }
}