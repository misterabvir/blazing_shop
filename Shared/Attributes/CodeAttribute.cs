using System.ComponentModel.DataAnnotations;

namespace Shared.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public partial class CodeAttribute(int length) : ValidationAttribute
{
    private readonly int _length = length;

    public override bool IsValid(object? value) => value is not null && value is string stringValue && stringValue.Length == _length;

    public override string FormatErrorMessage(string name)
    {
        return "Verification code should be " + _length + " characters long";
    }
}
