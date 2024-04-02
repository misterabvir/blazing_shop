﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RelationCategoryProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "common",
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("3e320d7f-c09d-49d3-96d7-5b20b8346215"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("4802dba6-5e8d-4e23-a83d-549f1e8bf97a"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("b1271d99-2909-42a4-b8b8-62cde6e808d6"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("161a87eb-c8da-48da-9654-cea51656f60d"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("7d438ef0-9719-4a2d-b447-e6ea7419bf42"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("8a5f332a-2088-4b25-964e-42c54fb23d09"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("905d2de4-cce5-43b5-b927-29c650761537"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("ada0c7ef-e010-4633-b091-99f68bfdd0e6"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("cb08880a-1906-489d-9516-25a15289418b"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("d1dc0494-dde8-41d5-80d5-1958d1201dec"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("d8c1b0b4-68cd-4b93-bdcd-f653f592c3e1"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("ef55828e-cb70-4f26-89af-0c6e8fd5eb44"));

            migrationBuilder.CreateTable(
                name: "categories_products",
                schema: "common",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_categories_products_categories_category_id",
                        column: x => x.category_id,
                        principalSchema: "common",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_categories_products_products_product_id",
                        column: x => x.product_id,
                        principalSchema: "common",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "common",
                table: "categories",
                columns: new[] { "category_id", "icon", "title", "url" },
                values: new object[,]
                {
                    { new Guid("1f9a7368-a37c-4271-8c3b-e4b0cb10027f"), "bi bi-controller", "Video Games", "video-games" },
                    { new Guid("7f121bdd-7103-4ceb-8539-a05972260f04"), "bi bi-camera", "Electronics", "electronics" },
                    { new Guid("d255e60e-abe5-47d6-a25a-5b45c999fb6a"), "bi bi-book", "Books", "books" }
                });

            migrationBuilder.InsertData(
                schema: "common",
                table: "products",
                columns: new[] { "product_id", "created_at", "description", "image", "original_price", "price", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("0e50d58d-ca9e-4dd9-bad0-22b82e481dbc"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3825), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", 159.99m, 159.99m, "Xbox", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3826) },
                    { new Guid("18ffa6da-99ad-47b3-a154-b395318c16aa"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3803), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", 7.99m, 7.99m, "Ready Player One", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3804) },
                    { new Guid("41056a9b-9108-43e2-bb60-607791af18d9"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3854), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", 9.99m, 9.99m, "Diablo II", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3854) },
                    { new Guid("491cc292-5c7e-4b27-9403-0e8717f5e6a6"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3818), "The Pentax Spotmatic refers to a family of 35mm single-lens reflex cameras manufactured by the Asahi Optical Co. Ltd., later known as Pentax Corporation, between 1964 and 1976.", "https://upload.wikimedia.org/wikipedia/commons/e/e9/Honeywell-Pentax-Spotmatic.jpg", 166.66m, 166.66m, "Pentax Spotmatic", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3818) },
                    { new Guid("4dac4758-66ca-4988-bff7-22d3e465d0b6"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3860), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", 14.99m, 14.99m, "Day of the Tentacle", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3860) },
                    { new Guid("72bc65a9-ea2f-4f0a-a584-c80b777f2eb8"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3840), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", 73.74m, 73.74m, "Super Nintendo Entertainment System", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3841) },
                    { new Guid("a9bd62dd-8c69-4292-bf57-fcf8405d36a7"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3847), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", 8.19m, 8.19m, "Half-Life 2", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3848) },
                    { new Guid("ca2431c3-0ffa-4d04-b5fd-a58271f7d69b"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3781), "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", 9.99m, 9.99m, "The Hitchhiker's Guide to the Galaxy", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3784) },
                    { new Guid("ec485577-bcf0-4c5e-bc59-2d27f9f2c9d1"), new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3811), "Nineteen Eighty-Four: A Novel, often published as 1984, is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.", "https://i.pinimg.com/originals/db/0b/0e/db0b0e8e11fb40b303c7c2583a5aea5f.jpg", 6.99m, 6.99m, "Nineteen Eighty-Four", new DateTime(2024, 4, 2, 9, 30, 6, 131, DateTimeKind.Utc).AddTicks(3812) }
                });

            migrationBuilder.CreateIndex(
                name: "ix_categories_products_category_id",
                schema: "common",
                table: "categories_products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_categories_products_product_id",
                schema: "common",
                table: "categories_products",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories_products",
                schema: "common");

            migrationBuilder.DeleteData(
                schema: "common",
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("1f9a7368-a37c-4271-8c3b-e4b0cb10027f"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("7f121bdd-7103-4ceb-8539-a05972260f04"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "categories",
                keyColumn: "category_id",
                keyValue: new Guid("d255e60e-abe5-47d6-a25a-5b45c999fb6a"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("0e50d58d-ca9e-4dd9-bad0-22b82e481dbc"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("18ffa6da-99ad-47b3-a154-b395318c16aa"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("41056a9b-9108-43e2-bb60-607791af18d9"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("491cc292-5c7e-4b27-9403-0e8717f5e6a6"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("4dac4758-66ca-4988-bff7-22d3e465d0b6"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("72bc65a9-ea2f-4f0a-a584-c80b777f2eb8"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("a9bd62dd-8c69-4292-bf57-fcf8405d36a7"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("ca2431c3-0ffa-4d04-b5fd-a58271f7d69b"));

            migrationBuilder.DeleteData(
                schema: "common",
                table: "products",
                keyColumn: "product_id",
                keyValue: new Guid("ec485577-bcf0-4c5e-bc59-2d27f9f2c9d1"));

            migrationBuilder.InsertData(
                schema: "common",
                table: "categories",
                columns: new[] { "category_id", "icon", "title", "url" },
                values: new object[,]
                {
                    { new Guid("3e320d7f-c09d-49d3-96d7-5b20b8346215"), "bi bi-camera", "Electronics", "electronics" },
                    { new Guid("4802dba6-5e8d-4e23-a83d-549f1e8bf97a"), "bi bi-controller", "Video Games", "video-games" },
                    { new Guid("b1271d99-2909-42a4-b8b8-62cde6e808d6"), "bi bi-book", "Books", "books" }
                });

            migrationBuilder.InsertData(
                schema: "common",
                table: "products",
                columns: new[] { "product_id", "created_at", "description", "image", "original_price", "price", "title", "updated_at" },
                values: new object[,]
                {
                    { new Guid("161a87eb-c8da-48da-9654-cea51656f60d"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3203), "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.", "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg", 14.99m, 14.99m, "Day of the Tentacle", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3203) },
                    { new Guid("7d438ef0-9719-4a2d-b447-e6ea7419bf42"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3188), "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.", "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg", 8.19m, 8.19m, "Half-Life 2", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3188) },
                    { new Guid("8a5f332a-2088-4b25-964e-42c54fb23d09"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3121), "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune.", "https://upload.wikimedia.org/wikipedia/en/a/a4/Ready_Player_One_cover.jpg", 7.99m, 7.99m, "Ready Player One", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3122) },
                    { new Guid("905d2de4-cce5-43b5-b927-29c650761537"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3097), "The Hitchhiker's Guide to the Galaxy (sometimes referred to as HG2G, HHGTTG, H2G2, or tHGttG) is a comedy science fiction series created by Douglas Adams.", "https://upload.wikimedia.org/wikipedia/en/b/bd/H2G2_UK_front_cover.jpg", 9.99m, 9.99m, "The Hitchhiker's Guide to the Galaxy", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3101) },
                    { new Guid("ada0c7ef-e010-4633-b091-99f68bfdd0e6"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3195), "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.", "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png", 9.99m, 9.99m, "Diablo II", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3196) },
                    { new Guid("cb08880a-1906-489d-9516-25a15289418b"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3180), "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.", "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg", 73.74m, 73.74m, "Super Nintendo Entertainment System", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3181) },
                    { new Guid("d1dc0494-dde8-41d5-80d5-1958d1201dec"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3139), "The Pentax Spotmatic refers to a family of 35mm single-lens reflex cameras manufactured by the Asahi Optical Co. Ltd., later known as Pentax Corporation, between 1964 and 1976.", "https://upload.wikimedia.org/wikipedia/commons/e/e9/Honeywell-Pentax-Spotmatic.jpg", 166.66m, 166.66m, "Pentax Spotmatic", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3139) },
                    { new Guid("d8c1b0b4-68cd-4b93-bdcd-f653f592c3e1"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3130), "Nineteen Eighty-Four: A Novel, often published as 1984, is a dystopian social science fiction novel by English novelist George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime.", "https://i.pinimg.com/originals/db/0b/0e/db0b0e8e11fb40b303c7c2583a5aea5f.jpg", 6.99m, 6.99m, "Nineteen Eighty-Four", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3130) },
                    { new Guid("ef55828e-cb70-4f26-89af-0c6e8fd5eb44"), new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3147), "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.", "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg", 159.99m, 159.99m, "Xbox", new DateTime(2024, 4, 2, 9, 5, 10, 310, DateTimeKind.Utc).AddTicks(3147) }
                });
        }
    }
}
