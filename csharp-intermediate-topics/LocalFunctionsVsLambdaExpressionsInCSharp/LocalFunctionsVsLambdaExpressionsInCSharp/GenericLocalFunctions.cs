namespace LocalFunctionsVsLambdaExpressionsInCSharp;

public static class GenericLocalFunctions
{
    public static void SwapElements(ref object left, ref object right)
    {
        static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        Swap(ref left, ref right);
    }
}