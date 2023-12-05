namespace FuncInCsharp;

public static class ArrayHelper
{
    public static void Recalculate(int[] values, Func<int, int> operation)
    {
        for (var i = 0; i < values.Length; i++)
        {
            values[i] = operation(values[i]);
        }
    }
}
