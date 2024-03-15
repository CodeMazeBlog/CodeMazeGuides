using System.ComponentModel.DataAnnotations;

namespace ConditionalRequiredAttributeValidation.Validators;

public class RequiredIfCustomAttribute(string otherProperty, object targetValue) : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyValue = validationContext.ObjectType
                                                  .GetProperty(otherProperty)?
                                                  .GetValue(validationContext.ObjectInstance);

        if (otherPropertyValue is null || !otherPropertyValue.Equals(targetValue)) return ValidationResult.Success;

        if (value is null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return new ValidationResult(ErrorMessage ?? "This field is required.");
        }
            
        return ValidationResult.Success;
    }
}