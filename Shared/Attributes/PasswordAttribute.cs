using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Shared.Attributes;

[AttributeUsage(AttributeTargets.Property) ]
public partial class PasswordAttribute : ValidationAttribute
{
    private readonly Regex _regex = PasswordRegex();

    public override bool IsValid(object? value) => value is not null && value is string stringValue && _regex.IsMatch(stringValue);

    public override string FormatErrorMessage(string name)
    {
        return "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, one special symbol";
    }

    [GeneratedRegex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")]
    private static partial Regex PasswordRegex();
}
