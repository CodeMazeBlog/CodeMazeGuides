using System.Buffers;

namespace DeleteElementsFromAnArray
{
    public static partial class Methods
    {
        public static int[] DeleteWithPooledArray(int[] source, int elementToRemove)
        {
            var tempArray = ArrayPool<int>.Shared.Rent(source.Length);
            try
            {
                var tempSpan = tempArray.AsSpan();
                var index = 0;
                foreach (var element in source.AsSpan())
                {
                    if (element != elementToRemove) tempSpan[index++] = element;
                }

                return tempSpan[0..index].ToArray();
            }
            finally
            {
                ArrayPool<int>.Shared.Return(tempArray);
            }
        }
    }
}
