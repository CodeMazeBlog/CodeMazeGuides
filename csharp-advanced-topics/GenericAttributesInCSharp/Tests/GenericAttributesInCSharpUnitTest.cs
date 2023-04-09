using GenericAttributesInCSharp;
using GenericAttributesInCSharp.Models;

namespace Tests;

public class GenericAttributesInCSharpUnitTest
{
    [Fact]
    public void WhenValidatorForValidTypeFetched_ThenReturnValidator()
    {
        var carValidator = ValidationHelper.GetValidator<Car>();

        Assert.NotNull(carValidator);
    }

    [Fact]
    public void WhenValidatorForInValidTypeFetched_ThenReturnNull()
    {
        var truckValidator = ValidationHelper.GetValidator<Truck>();

        Assert.Null(truckValidator);
    }

    [Theory]
    [InlineData(true, true)]
    [InlineData(false, false)]
    public void WhenCarValidated_ThenValidatesType(bool isConvertible, bool expectedValidationResult)
    {
        var carValidator = ValidationHelper.GetValidator<Car>();
        var car = new Car()
        {
            IsConvertible = isConvertible
        };

        var isValid = carValidator?.IsValid(car) ?? false;

        Assert.Equal(expectedValidationResult, isValid);
    }
}