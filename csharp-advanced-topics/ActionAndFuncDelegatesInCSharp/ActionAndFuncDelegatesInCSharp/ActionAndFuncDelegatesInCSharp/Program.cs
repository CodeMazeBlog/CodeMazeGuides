PlotGraph(x => 2 * x + 3);

static void PlotGraph(Func<int, int> func)
{
    for (var i = 0; i < 10; i++)
    {
        Console.WriteLine($"(x = {i}, y = {func(i)})");
    }
}

/*
 * Output
 *
 * (x = 0, y = 3)
 * (x = 1, y = 5)
 * (x = 2, y = 7)
 * (x = 3, y = 9)
 * (x = 4, y = 11)
 * (x = 5, y = 13)
 * (x = 6, y = 15)
 * (x = 7, y = 17)
 * (x = 8, y = 19)
 * (x = 9, y = 21)
 */