namespace PermutationsOfAString
{
    public class PanditasAlgorithm : IPermutation, IStringPermutation
    {
        #region Generic permutations for comparsment with HeapsAlgorithm
        public List<byte[]> GetPermutations(byte number)
        {
            var input = Enumerable.Range(0, number).Select(i => (byte)i).ToArray();

            return GeneratePermutations(input, false);
        }

        public void BenchmarkPermutations(byte[] input)
        {
            GeneratePermutations(input, true);
        }

        private List<byte[]> GeneratePermutations(byte[] input, bool doBenchmarks)
        {
            _Benchmarks = doBenchmarks;

            Array.Sort(input);

            var result = new List<byte[]>();
            result.AddCopy(input);
            while (NextPermutation(input))
            {
                if (!_Benchmarks) result.AddCopy(input);
            }

            return result;
        }

        public bool NextPermutation(byte[] number)
        {
            int i = number.Length - 2;
            while (i >= 0 && number[i] >= number[i + 1])
            {
                i--;
            }
            if (i < 0)
                return false;

            int j = number.Length - 1;
            while (number[j] <= number[i])
            {
                j--;
            }
            (number[i], number[j]) = (number[j], number[i]);

            Reverse(number, i + 1);

            return true;
        }

        private void Reverse(byte[] number, int start)
        {
            int i = start;
            int j = number.Length - 1;
            while (i < j)
            {
                (number[i], number[j]) = (number[j], number[i]);
                i++;
                j--;
            }
        }
        #endregion

        #region Permutations of strings
        public List<string> GetPermutations(string input)
        {
            return GeneratePermutations(input);
        }

        public string GetNextPermutation(string input)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            var array = input.ToCharArray();
            Span<char> spanInput = array.AsSpan();

            if (NextPermutation(spanInput))
                return new string(spanInput);

            return string.Join("", input.ToCharArray().OrderBy(c => c).ToArray());
        }

        private List<string> GeneratePermutations(string input)
        {
            var array = input.ToCharArray().OrderBy(c => c).ToArray();
            Span<char> spanInput = array.AsSpan();

            var result = new List<string>() { new string(spanInput) };
            while (NextPermutation(spanInput))
                result.Add(new string(spanInput));

            return result;
        }

        public bool NextPermutation(Span<char> input)
        {
            int i = input.Length - 2;
            while (i >= 0 && input[i] >= input[i + 1])
            {
                i--;
            }
            if (i < 0)
                return false;

            int j = input.Length - 1;
            while (input[j] <= input[i])
            {
                j--;
            }
            (input[i], input[j]) = (input[j], input[i]);

            Reverse(input, i + 1);

            return true;
        }

        private void Reverse(Span<char> input, int start)
        {
            int i = start;
            int j = input.Length - 1;
            while (i < j)
            {
                (input[i], input[j]) = (input[j], input[i]);
                i++;
                j--;
            }
        }
        #endregion

        private bool _Benchmarks;
    }
}
