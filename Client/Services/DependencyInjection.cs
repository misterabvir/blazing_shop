using Client.Services.Authentications;
using Client.Services.Categories;
using Client.Services.Icons;
using Client.Services.Products;
using Client.Services.Requests;
using Client.Services.Sessions;
using Client.Services.ToastMessages;
using Shared.Authentications;

namespace Client.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services){     
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();      
        services.AddScoped<IIconService, IconService>();      
        services.AddScoped<IToastMessageService, ToastMessageService>();      
        services.AddScoped<ISessionStorage, SessionStorage>();      
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        IConfiguration configuration = new ConfigurationBuilder()
        .AddJsonFile("Authentications/tokensettings.json")
        .Build();
        services.AddSingleton(provider => 
            configuration.GetSection(JwtSettings.SectionName).Get<JwtSettings>() 
            ?? throw new Exception("JwtSettings is not found"));
        return services;
    }

}