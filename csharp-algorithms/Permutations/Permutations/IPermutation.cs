namespace ListAllThePermutationsOfStringInCSharp
{
    public interface IPermutation
    {
        List<byte[]> GetPermutations(byte number);

        void BenchmarkPermutations(byte number);
    }
}
