using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Shared.Authentications;

public class JwtSettings
{
    public string SecurityKey { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpiresInMinutes { get; set; } = 0;
    public bool ValidateAudience {get;set;}
    public bool ValidateIssuer {get;set;}
    public bool ValidateLifetime {get;set;}
    public bool ValidateIssuerSigningKey { get; set; }


    public static string SectionName => nameof(JwtSettings);

    public SymmetricSecurityKey SymmetricSecurityKey => new(Encoding.UTF8.GetBytes(SecurityKey));

    public TokenValidationParameters TokenValidationParameters => new()
    {
        ValidateAudience = ValidateAudience,
        ValidateIssuer = ValidateIssuer,
        ValidateLifetime = ValidateLifetime,
        ValidateIssuerSigningKey = ValidateIssuerSigningKey,
        ValidIssuer = Issuer,
        ValidAudience = Audience,
        IssuerSigningKey = SymmetricSecurityKey
    };
}
