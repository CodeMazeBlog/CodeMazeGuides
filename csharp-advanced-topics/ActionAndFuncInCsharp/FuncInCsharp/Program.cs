var values = new[] { 0, 10, 20 };
Recalculate(values, Square);

Console.WriteLine(string.Join(' ', values));
static void Recalculate(int[] values, Func<int, int> func)
{
    for (var i = 0; i < values.Length; i++)
    {
        values[i] = func(values[i]);
    }
}

static int Square(int value) => value * value;
