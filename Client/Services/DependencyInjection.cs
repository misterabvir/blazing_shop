using Client.Services.Authentications;
using Client.Services.Categories;
using Client.Services.Icons;
using Client.Services.Products;
using Client.Services.Requests;
using Client.Services.ToastMessages;

namespace Client.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(this IServiceCollection services){     
        services.AddScoped<IRequestService, RequestService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();      
        services.AddScoped<IIconService, IconService>();      
        services.AddScoped<IToastMessageService, ToastMessageService>();      
        services.AddScoped<IAuthenticationService, AuthenticationService>();      
        return services;
    }

}