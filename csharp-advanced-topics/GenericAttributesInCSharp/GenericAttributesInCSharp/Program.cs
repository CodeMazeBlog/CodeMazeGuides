using GenericAttributesInCSharp.Models;

namespace GenericAttributesInCSharp;

public static class Program
{
    public static void Main()
    {
        var carValidator = ValidationHelper.GetValidator<Car>();
        var car = new Car()
        {
            IsConvertible = true
        };

        Console.WriteLine(carValidator?.IsValid(car));
    }
}