using Microsoft.EntityFrameworkCore;
using Domain.Categories;
using Domain.Products;
using Domain.Users;

namespace Persistence.Contexts;

public class BlazingShopContext(DbContextOptions<BlazingShopContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlazingShopContext).Assembly);
    }

}