using GenericAttributesInCSharp.Models;

namespace GenericAttributesInCSharp.Validators;

public class CarValidator : IVehicleValidator<Car>
{
    public bool IsValid(Car car) => car.IsConvertible;
}