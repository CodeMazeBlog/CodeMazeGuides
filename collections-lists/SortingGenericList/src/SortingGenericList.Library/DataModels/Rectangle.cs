namespace SortingGenericList.Library.DataModels;

public class Rectangle : Shape
{
    public override double Area { get; }
    public override double Circumference { get; }

    public Rectangle(double length, double width)
    {
        Area = length * width;
        Circumference = 2 * (length + width);
    }
}