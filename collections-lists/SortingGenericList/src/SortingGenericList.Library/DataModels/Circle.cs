namespace SortingGenericList.Library.DataModels;

public sealed class Circle : Shape
{
    public override double Area { get; }
    public override double Circumference { get; }

    public Circle(double radius)
    {
        if (radius < 0.0) throw new ArgumentException("Radius cannot be negative", nameof(radius));

        Area = Math.PI * radius * radius;
        Circumference = Math.PI * 2 * radius;
    }
}