using System;

class Shape
{
    public virtual string GetShapeType() => "Shape";
}

class Circle : Shape
{
    public override string GetShapeType() => "Circle";
}

class Rectangle : Shape
{
    public override string GetShapeType() => "Rectangle";
}

class Program
{
    static void PrintShapeType(Func<Shape, string> shapeTypeGetter)
    {
        Shape shape = new Shape();
        Console.WriteLine("Shape Type: " + shapeTypeGetter(shape));

        Circle circle = new Circle();
        Console.WriteLine("Circle Type: " + shapeTypeGetter(circle));

        Rectangle rectangle = new Rectangle();
        Console.WriteLine("Rectangle Type: " + shapeTypeGetter(rectangle));
    }

    static void Main()
    {
        // Using Func with contravariant type parameters to get shape type
        PrintShapeType(shape => shape.GetShapeType());
    }
}
