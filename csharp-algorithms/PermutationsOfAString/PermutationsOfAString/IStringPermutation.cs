namespace PermutationsOfAString
{
    public interface IStringPermutation
    {
        List<string> GetPermutations(string input);
        string GetNextPermutation(string input);
    }
}
