namespace ListAllThePermutationsOfStringInCSharp
{
    public class HeapsAlgorithm : IPermutation
    {
        private bool _benchmarks;

        public List<byte[]> GetPermutations(byte number)
        {
            return GeneratePermutations(number, false);
        }

        public void BenchmarkPermutations(byte number)
        {
            GeneratePermutations(number, true);
        }

        private List<byte[]> GeneratePermutations(byte number, bool doBenchmarks)
        {
            _benchmarks = doBenchmarks;

            var input = Enumerable.Range(0, number).Select(i => (byte)i).ToArray();
            var result = new List<byte[]>();
            Heaps(result, input, number);

            return result;
        }

        private void Heaps(List<byte[]> result, byte[] input, byte size)
        {
            if (size == 1)
            {
                if (!_benchmarks) result.AddCopy(input);
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    Heaps(result, input, (byte)(size - 1));

                    if (size % 2 == 1)
                        (input[size - 1], input[0]) = (input[0], input[size - 1]);
                    else
                        (input[size - 1], input[i]) = (input[i], input[size - 1]);
                }
            }
        }
    }
}
