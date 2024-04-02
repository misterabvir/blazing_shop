using Domain.Products;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> product)
    {
        product.ToTable("products", "common");
        product.HasKey(p => p.Id);
        product.Property(p => p.Id)
            .HasConversion(id => id.Value, value => ProductId.Create(value))
            .HasColumnName("product_id")
            .ValueGeneratedNever();

        product.Property(p => p.Title).HasConversion(title => title.Value, value => Title.Create(value));
        product.Property(p => p.Description).HasConversion(description => description.Value, value => Description.Create(value));
        product.Property(p => p.Image).HasConversion(image => image.Value, value => Image.Create(value));
        product.Property(p => p.Price).HasConversion(price => price.Value, value => Price.Create(value));
        product.Property(p => p.OriginalPrice).HasConversion(price => price.Value, value => Price.Create(value));
        product.Property(p => p.CreatedAt).HasConversion(date => date.Value, value => Date.Create(value));
        product.Property(p => p.UpdatedAt).HasConversion(date => date.Value, value => Date.Create(value));


        product.HasData(
            Product.Create(
                Title.Create("The Hitchhiker's Guide to the Galaxy"),
                Description.Create("The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams."),
                Image.Create("https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg"),
                Price.Create(9.99m)
                ).Value!,
            Product.Create(
                Title.Create("Ready Player One"),
                Description.Create("Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune."),
                Image.Create("https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg"),
                Price.Create(7.99m)
            ).Value!,
            Product.Create(
                Title.Create("Nineteen Eighty-Four"),
                Description.Create("Nineteen Eighty-Four: A Novel, often published as 1984, is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime."),
                Image.Create("https://i.pinimg.com/originals/db/0b/0e/db0b0e8e11fb40b303c7c2583a5aea5f.jpg"),
                Price.Create(6.99m)
            ).Value!,
            Product.Create(
                Title.Create("Pentax Spotmatic"),
                Description.Create("The Pentax Spotmatic refers to a family of 35mm single-lens reflex cameras manufactured by the Asahi Optical Co. Ltd., later known as Pentax Corporation, between 1964 and 1976."),
                Image.Create("https://upload.wikimedia.org/wikipedia/commons/e/e9/Honeywell-Pentax-Spotmatic.jpg"),
                Price.Create(166.66m)
            ).Value!,
            Product.Create(
                Title.Create("Xbox"),
                Description.Create("The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft."),
                Image.Create("https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg"),
                Price.Create(159.99m)
            ).Value!,
            Product.Create(
                Title.Create("Super Nintendo Entertainment System"),
                Description.Create("The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea."),
                Image.Create("https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg"),
                Price.Create(73.74m)
            ).Value!,
            Product.Create(
                Title.Create("Half-Life 2"),
                Description.Create("Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay."),
                Image.Create("https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg"),
                Price.Create(8.19m)
            ).Value!,
            Product.Create(
                Title.Create("Diablo II"),
                Description.Create("Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS."),
                Image.Create("https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png"),
                Price.Create(9.99m)
            ).Value!,
            Product.Create(
                Title.Create("Day of the Tentacle"),
                Description.Create("Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion."),
                Image.Create("https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg"),
                Price.Create(14.99m)
            ).Value!);

    }
}
