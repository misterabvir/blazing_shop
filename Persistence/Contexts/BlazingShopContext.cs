using Microsoft.EntityFrameworkCore;
using Domain.Categories;
using Domain.Products;

namespace Persistence.Contexts;

public class BlazingShopContext : DbContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseNpgsql("Host=localhost;Port=5432;Database=blazing_shop_db;Username=user;Password=password")
        .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlazingShopContext).Assembly);
    }

}