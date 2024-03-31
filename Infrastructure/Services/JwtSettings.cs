using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure.Services;

internal class JwtSettings
{
    public string SecurityKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpiresInMinutes { get; set; } = 0;

    public static string SectionName => nameof(JwtSettings);

    public SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.UTF8.GetBytes(SecurityKey));

    internal TokenValidationParameters TokenValidationParameters => new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = Issuer,
        ValidAudience = Audience,
        IssuerSigningKey = SymmetricSecurityKey
    };
}
