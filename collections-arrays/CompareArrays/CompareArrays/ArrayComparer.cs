using System.Collections;

namespace CompareArrays
{
    public class ArrayComparer
    {
        public bool EqualityOperator(int[] firstArray, int[] secondArray)
        {
            return firstArray == secondArray;
        }

        public bool ForLoop(int[] firstArray, int[] secondArray)
        {
            if (firstArray.Length != secondArray.Length)
                return false;

            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                    return false;
            }

            return true;
        }

        public bool EnumerableSequenceEqual(int[] firstArray, int[] secondArray)
        {
            return Enumerable.SequenceEqual(firstArray, secondArray);
        }

        public bool AsSpanSequenceEqual(int[] firstArray, int[] secondArray)
        {
            return firstArray.AsSpan().SequenceEqual(secondArray);
        }

        public bool EnumerableSequenceEqual(Article[] articleArray, Article[] articleArrayCopy)
        {
            return Enumerable.SequenceEqual(articleArray, articleArrayCopy, new Article());
        }

        public bool EnumerableEquals(int[] firstArray, int[] secondArray)
        {
            return Equals(firstArray, secondArray);
        }

        public bool EnumerableReferenceEquals(int[] firstArray, int[] secondArray)
        {
            return ReferenceEquals(firstArray, secondArray);
        }

        public bool StructuralEquatable(int[] firstArray, int[] secondArray)
        {
            IStructuralEquatable structuralEquatable = firstArray;
            
            return structuralEquatable.Equals(secondArray, StructuralComparisons.StructuralEqualityComparer);
        }
    }
}
