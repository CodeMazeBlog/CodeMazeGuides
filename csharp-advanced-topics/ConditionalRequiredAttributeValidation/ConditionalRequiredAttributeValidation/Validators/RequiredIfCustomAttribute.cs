using System.ComponentModel.DataAnnotations;

namespace ConditionalRequiredAttributeValidation.Validators;

public class RequiredIfCustomAttribute(string otherProperty, object targetValue) : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyValue = validationContext.ObjectType.GetProperty(otherProperty)?.GetValue(validationContext.ObjectInstance);

        if (otherPropertyValue == null || !otherPropertyValue.Equals(targetValue)) return ValidationResult.Success;

        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult(ErrorMessage ?? "This field is required.");
        }
            
        return ValidationResult.Success;
    }
}