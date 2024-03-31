using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Contexts;

internal class BlazingShopContextDesignTimeFactory : IDesignTimeDbContextFactory<BlazingShopContext>
{
    public BlazingShopContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BlazingShopContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=blazing_shop_db;Username=user;Password=password");
        optionsBuilder.UseSnakeCaseNamingConvention();
        return new BlazingShopContext(optionsBuilder.Options);
    }
}
