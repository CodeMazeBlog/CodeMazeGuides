namespace ActionAndFuncDelegatesInCSharp;

public static class PlotGraphUsingFuncDelegate
{
    public static List<(int x, int y)> PlotGraph(Func<int, int> func)
    {
        var points = new List<(int, int)>();
        for (var i = 0; i < 10; i++)
        {
            points.Add((i, func(i))); 
        }

        return points;
    } 
}