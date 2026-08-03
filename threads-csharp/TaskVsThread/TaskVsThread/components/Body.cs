namespace TaskVsThread;

public class Body
{
    public int Weight { get; init; }
    public int Length { get; init; }
    public int Width { get; init; }

    public Body(int weight, int length, int width)
    {
        Weight = weight;
        Length = length;
        Width = width;
    }
}
