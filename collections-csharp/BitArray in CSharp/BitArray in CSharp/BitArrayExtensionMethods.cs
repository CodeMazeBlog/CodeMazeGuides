using System.Collections;

namespace BitArray_in_CSharp
{
    public static class BitArrayExtensionMethods
    {
        public static void Print(this BitArray bitArray)
        {
            foreach (bool bit in bitArray)
            {
                Console.Write(bit + " ");
            }
            Console.WriteLine();
        }
    }
}
