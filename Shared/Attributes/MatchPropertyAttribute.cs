using System.ComponentModel.DataAnnotations;

namespace Shared.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class MatchPropertyAttribute(string matchedPropertyName) : ValidationAttribute
{
    private readonly string _matchedPropertyName = matchedPropertyName;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var propertyInfo = validationContext.ObjectType.GetProperty(_matchedPropertyName);

        if (propertyInfo == null)
            return new ValidationResult($"Property {_matchedPropertyName} not found.");

        var propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (!Equals(value, propertyValue))
            return new ValidationResult(ErrorMessage ?? $"The {_matchedPropertyName} and {validationContext.MemberName} fields do not match.");

        return ValidationResult.Success;
    }
}