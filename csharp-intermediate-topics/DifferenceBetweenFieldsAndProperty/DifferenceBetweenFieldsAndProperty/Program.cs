namespace DifferenceBetweenFieldsAndProperty;

internal class Program
{
    static void Main(string[] args)
    {
        var person = new Person { HasSuperPowers = true };
        person.UpdateName("Sam Doe");
        Person.Age = 19;

        Console.Write("Enter the width of the rectangle: ");
        int.TryParse(Console.ReadLine(), out var width);

        Console.Write("Enter the height of the rectangle: ");
        int.TryParse(Console.ReadLine(), out var height);

        Console.Write("Enter the scaling factor: ");
        double.TryParse(Console.ReadLine(), out var scalingFactor);

        var rectangle = new Rectangle { Width = width, Height = height };
        Console.WriteLine($"Dimensions of the initial rectangle: {rectangle.Width} X {rectangle.Height}");

        Rectangle.ScalingFactor = scalingFactor;

        var scaledRectangle = rectangle.CreateScaledRectangle();
        Console.WriteLine($"Dimensions of the scaled rectangle: {scaledRectangle.Width} X {scaledRectangle.Height}");

        var newRectangle = new Rectangle { Width = 10.5, Height = 5.5 };
        var newRectangleScaled = newRectangle.CreateScaledRectangle();
        Console.WriteLine($"Dimensions of the new rectangle after scaling: {newRectangleScaled.Width} X {newRectangleScaled.Height}");
    }
}
