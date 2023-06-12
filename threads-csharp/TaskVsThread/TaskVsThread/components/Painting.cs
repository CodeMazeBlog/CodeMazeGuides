namespace TaskVsThread;

public class Painting
{
    public string Color { get; init; }
    public int PaintArea { get; init; }

    public Painting(string color, int paintArea)
    {
        Color = color;
        PaintArea = paintArea;
    }
}
