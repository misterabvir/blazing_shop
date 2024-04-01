using Application.Base.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Authentications;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentications();

        return services;
    }


    private static IServiceCollection AddAuthentications(this IServiceCollection services)
    {
        IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("Authentications/tokensettings.json")
        .Build();
        var jwtSettings = configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>()
            ?? throw new InvalidOperationException("JwtSettings not found");
        services.AddSingleton(jwtSettings);

        services.AddScoped<IJwtTokenService, JwtTokenService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = jwtSettings.TokenValidationParameters);

        return services;
    }
}
