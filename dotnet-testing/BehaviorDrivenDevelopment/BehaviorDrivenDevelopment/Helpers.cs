public static class Helpers
{
    public static int SumTwoNumbers(int a, int b)
    {
        return a + b;
    }

    public static int SubtractTwoNumbers(int a, int b)
    {
        return a - b;
    }

    public static int GetAverage(int a, int b, int c)
    {
        return (int)new int[] { a, b, c }.Average();
    }
}
