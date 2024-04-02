using Application.Base.Services;
using Domain.Users;
using Microsoft.IdentityModel.Tokens;
using Shared.Authentications;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Infrastructure.Services;

internal class JwtTokenService(JwtSettings jwtSettings) : IJwtTokenService
{
    private readonly JwtSettings _jwtSettings = jwtSettings;

    public string GetJwtToken(User user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiresInMinutes);

        var signingCredentials = new SigningCredentials(_jwtSettings.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(type: ClaimTypes.NameIdentifier, value: user.Id.Value.ToString()),
            new Claim(type: ClaimTypes.Email, value: user.Contact.Email.Value),
            new Claim(type: ClaimTypes.MobilePhone, value: user.Contact.Phone.Value),
            new Claim(type: ClaimTypes.Role, value: user.Role.Value),
            new Claim(type: ClaimTypes.Expiration, value: expiration.ToString()),
        };

        var securityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: expiration
            );

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
