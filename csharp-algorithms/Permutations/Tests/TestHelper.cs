using ListAllThePermutationsOfStringInCSharp;

namespace Tests
{
    public static class TestHelper
    {
        public static void AssertAreEqual(IPermutation permutationAlgorithm, byte number, List<string> expected)
        {
            var actual = permutationAlgorithm.GetPermutations(number);
            var convertedActual = ByteArray2StringConverter.ListOfBytesToListOfString(actual);

            CollectionAssert.AreEquivalent(expected, convertedActual);
        }

        public static void AssertAreAlgorithms(IPermutation permutationAlgorithm1, IPermutation permutationAlgorithm2, byte number)
        {
            var resultOfAlgorithm1 = permutationAlgorithm1.GetPermutations(number);
            var resultOfAlgorithm2 = permutationAlgorithm2.GetPermutations(number);

            var convertedResultOfAlgorithm1 = ByteArray2StringConverter.ListOfBytesToListOfString(resultOfAlgorithm1);
            var convertedResultOfAlgorithm2 = ByteArray2StringConverter.ListOfBytesToListOfString(resultOfAlgorithm2);

            CollectionAssert.AreEquivalent(convertedResultOfAlgorithm1, convertedResultOfAlgorithm2);
        }
    }
}
