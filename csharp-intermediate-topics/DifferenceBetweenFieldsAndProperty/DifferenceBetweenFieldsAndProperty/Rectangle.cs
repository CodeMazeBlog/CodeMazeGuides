namespace DifferenceBetweenFieldsAndProperty;

public class Rectangle
{
    private double _width;
    private double _height;

    public double Width
    {
        get => _width;
        init
        {
            if (value < 0)
                throw new ArgumentException("A Rectangle can't have negative width", nameof(value));

            _width = value;
        }
    }

    public double Height
    {
        get => _height;
        init
        {
            if (value < 0)
                throw new ArgumentException("A Rectangle can't have negative height", nameof(value));

            _height = value;
        }
    }
    public static double ScalingFactor { get; set; } = 1.0;

    public Rectangle() { }

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