using GenericAttributesInCSharp.Validators;

namespace GenericAttributesInCSharp;

[AttributeUsage(AttributeTargets.Class)]
public class VehicleValidatorAttribute<T, TEntity> : Attribute
where T : class, IVehicleValidator<TEntity>
where TEntity : class
{
}