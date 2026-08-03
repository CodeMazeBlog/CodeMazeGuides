using GenericAttributesInCSharp.Validators;
using System.Reflection;

namespace GenericAttributesInCSharp;

public static class ValidationHelper
{
    public static IVehicleValidator<T>? GetValidator<T>()
        where T : class
    {
        var modelType = typeof(T);

        var validatorAttr = modelType
            .GetCustomAttribute(typeof(VehicleValidatorAttribute<,>));

        if (validatorAttr is not null)
        {
            var validatorType = validatorAttr
                .GetType()
                .GetGenericArguments()
                .First();

            return Activator.CreateInstance(validatorType) as IVehicleValidator<T>;
        }

        return null;
    }
}