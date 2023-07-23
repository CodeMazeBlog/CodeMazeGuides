namespace PermutationsOfAString
{
    public interface IPermutation
    {
        List<byte[]> GetPermutations(byte number);
        void BenchmarkPermutations(byte[] input);
    }
}
