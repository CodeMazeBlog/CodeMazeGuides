namespace ActionAndFuncDelegatesInCSharp;

public static class PlotGraphUsingCustomDelegate
{
    public delegate int GraphDelegate(int x);

    public static List<(int x, int y)> PlotGraph(GraphDelegate func)
    {
        var points = new List<(int, int)>();
        for (var i = 0; i < 10; i++)
        {
           points.Add((i, func(i))); 
        }

        return points;
    } 
}