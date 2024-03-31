using Application.Base.Repositories;
using Domain.Categories.ValueObjects;
using Domain.Products;
using Domain.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Shared.Pagination;
namespace Persistence.Repositories;

internal class ProductRepository(BlazingShopContext context) : IProductRepository
{
    private readonly BlazingShopContext _context = context;
    public async Task<Pagination<Product>> GetAll(int page, int pageSize)
    {
        var count = await _context.Products.CountAsync();
        var skip = (page - 1) * pageSize;
        var take = pageSize;
        var items = await _context.Products.AsNoTracking().Skip(skip).Take(take).ToListAsync();
        var pagination = new Pagination<Product>()
        {
             Count = count,
             Items = items,
             Page = page,
             PageSize = pageSize
        };

        return pagination;
    }

    public async Task<Pagination<Product>> GetByCategory(CategoryId categoryId, int page, int pageSize)
    {
        var query = _context.Products.AsNoTracking().Where(p => p.CategoryId == categoryId);
        var count = await query.CountAsync();
        var skip = (page - 1) * pageSize;
        var take = pageSize;
        var items = await query.Skip(skip).Take(take).ToListAsync();
        var pagination = new Pagination<Product>()
        {
            Count = count,
            Items = items,
            Page = page,
            PageSize = pageSize
        };

        return pagination;
    }

    public async Task<Product?> GetById(ProductId productId) =>
        await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

    /*
    private static List<Category> Categories = [
                Category.Create (Title.Create("Books"), Icon.Create("bi bi-book"), Url.Create("books")),
                Category.Create (Title.Create("Electronics"), Icon.Create("bi bi-camera"), Url.Create("electronics")),
                Category.Create (Title.Create("Video Games"), Icon.Create("bi bi-controller"), Url.Create("video-games"))
            ];


    private static List<Product> Products = [
        Product.Create(            
            (Categories.First(c => c.Title.Value == "Books").Id as CategoryId)!,
            Title.Create("The Hitchhiker's Guide to the Galaxy"),
            Description.Create("The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams."),
            Image.Create("https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg"),
            Price.Create(9.99m)
            ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Books").Id as CategoryId)!,
            Title.Create("Ready Player One"),
            Description.Create("Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune."),
            Image.Create("https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg"),
            Price.Create(7.99m)
        ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Books").Id as CategoryId)!,
            Title.Create("Nineteen Eighty-Four"),
            Description.Create("Nineteen Eighty-Four: A Novel, often published as 1984, is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime."),
            Image.Create("https://i.pinimg.com/originals/db/0b/0e/db0b0e8e11fb40b303c7c2583a5aea5f.jpg"),
            Price.Create(6.99m)
        ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Electronics").Id as CategoryId)!,
            Title.Create("Pentax Spotmatic"),
            Description.Create("The Pentax Spotmatic refers to a family of 35mm single-lens reflex cameras manufactured by the Asahi Optical Co. Ltd., later known as Pentax Corporation, between 1964 and 1976."),
            Image.Create("https://upload.wikimedia.org/wikipedia/commons/e/e9/Honeywell-Pentax-Spotmatic.jpg"),
            Price.Create(166.66m)
        ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Electronics").Id as CategoryId)!,
            Title.Create("Xbox"),
            Description.Create("The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft."),
            Image.Create("https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg"),
            Price.Create(159.99m)
        ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Electronics").Id as CategoryId)!,
            Title.Create("Super Nintendo Entertainment System"),
            Description.Create("The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea."),
            Image.Create("https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg"),
            Price.Create(73.74m)
        ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Electronics").Id as CategoryId)!,
            Title.Create("Half-Life 2"),
            Description.Create("Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay."),
            Image.Create("https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg"),
            Price.Create(8.19m)
        ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Video Games").Id as CategoryId)!,
            Title.Create("Diablo II"),
            Description.Create("Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS."),
            Image.Create("https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png"),
            Price.Create(9.99m)
        ),
        Product.Create(
            (Categories.First(c => c.Title.Value == "Video Games").Id as CategoryId)!,
            Title.Create("Day of the Tentacle"),
            Description.Create("Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion."),
            Image.Create("https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg"),
            Price.Create(14.99m)
        )
    ];*/
    
}
