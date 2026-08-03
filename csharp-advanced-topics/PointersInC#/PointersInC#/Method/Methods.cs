namespace PointersInCSharp.Method;

public static class Methods
{
    public static unsafe void SwapChars(char* p1, char* p2) => (*p2, *p1) = (*p1, *p2);
    public static unsafe void DoubleOddValues(int[] numbers)
    {
        fixed (int* arrayPtr = numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                if (*(arrayPtr + i) % 2 != 0)
                    *(arrayPtr + i) *= 2;
            }
        }
    }
}