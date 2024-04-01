namespace Server;

public static class DependencyInjection
{
    public static IServiceCollection AddServer(this IServiceCollection services)
    {
       services.AddCors(options =>
        {
            options.AddPolicy("Allow",
                policy =>
                {
                    policy.AllowAnyOrigin();
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                });
        });
        services.AddEndpointsApiExplorer();
        services.AddControllers();

        return services;
    }

    public static WebApplication UseServer(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseCors("Allow");
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        return app;
    }
}
