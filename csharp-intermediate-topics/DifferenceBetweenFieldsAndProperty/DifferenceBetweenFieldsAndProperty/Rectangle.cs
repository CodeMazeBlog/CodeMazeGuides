namespace DifferenceBetweenFieldsAndProperty;

public class Rectangle
{
    public double Width { get; init; }
    public double Height { get; init; }
    public static double ScalingFactor { get; set; } = 1.0;

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public Rectangle CreateScaledRectangle()
    {
        return new Rectangle(Width * ScalingFactor, Height * ScalingFactor);
    }
}