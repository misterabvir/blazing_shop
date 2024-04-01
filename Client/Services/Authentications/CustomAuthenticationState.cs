using Client.Services.Sessions;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Authentications;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Client.Services.Authentications;

public class CustomAuthenticationStateProvider(ISessionStorage sessionStorage, JwtSettings jwtSettings) : AuthenticationStateProvider
{
    private readonly ClaimsIdentity _anonymous = new ClaimsIdentity();
    private readonly ISessionStorage _sessionStorage = sessionStorage;
    private readonly JwtSettings _jwtSettings = jwtSettings;
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var handler = new JwtSecurityTokenHandler();
        var token = await _sessionStorage.GetItem<string>("token");

        var identity = new ClaimsIdentity();
        if (handler.CanReadToken(token))
        {
            var readPrincipal = handler.ValidateToken(token, _jwtSettings.TokenValidationParameters, out var validatedToken);
            if(readPrincipal.Identity?.IsAuthenticated is true)
            {
                var claims = (validatedToken as JwtSecurityToken)!.Claims;
                identity = new ClaimsIdentity(claims, "Blazing Shop");
            }           
        }

        var principal = new ClaimsPrincipal(identity);
        var state = new AuthenticationState(principal);
        return state;
    }

    public void NotifyUserLogIn(string token)
    {
        _sessionStorage.SetItem("token", token);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void NotifyUserLogOut()
    {
        _sessionStorage.RemoveItem("token");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
} 