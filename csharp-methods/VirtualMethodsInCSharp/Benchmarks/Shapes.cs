namespace Benchmarks;

public interface IShape
{
    double CalculateArea();
}

public class Shape : IShape
{
    public virtual double CalculateArea() => 0;
}

public class Circle : Shape
{
    public double Radius { get; init; }

    public override double CalculateArea() => Math.PI * Radius * Radius;

    public double CalculateAreaNonVirtual() => Math.PI * Radius * Radius;
}

public sealed class SealedCircle : Shape
{
    public double Radius { get; init; }

    public override double CalculateArea() => Math.PI * Radius * Radius;
}

public class Rectangle : Shape
{
    public double Width { get; init; }

    public double Height { get; init; }

    public override double CalculateArea() => Width * Height;
}
