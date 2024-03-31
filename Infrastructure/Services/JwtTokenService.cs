using Application.Base.Services;
using Domain.Users;
using Domain.Users.Snapshots;
using Domain.Users.ValueObjects;
using Microsoft.IdentityModel.Tokens;
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
            new Claim(type: ClaimTypes.GivenName, value: user.Profile.FirstName.Value),
            new Claim(type: ClaimTypes.Surname, value: user.Profile.LastName.Value),
            new Claim(type: ClaimTypes.Expiration, value: expiration.ToString()),
            new Claim(type: ClaimTypes.UserData, value: UserSnapshot.Create(user).ToJson()),
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
