namespace GenericAttributesInCSharp.Validators;

public interface IVehicleValidator<T>
    where T : class
{
    bool IsValid(T entity);
}