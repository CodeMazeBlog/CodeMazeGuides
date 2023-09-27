using GenericAttributesInCSharp.Validators;

namespace GenericAttributesInCSharp.Models;

[VehicleValidator<CarValidator, Car>]
public class Car
{
    public bool IsConvertible { get; set; }
}