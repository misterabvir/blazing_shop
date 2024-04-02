using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "common");

            migrationBuilder.EnsureSchema(
                name: "accounts");

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "common",
                columns: table => new
                {
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    icon = table.Column<string>(type: "text", nullable: false),
                    url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_categories", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "common",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    original_price = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "accounts",
                columns: table => new
                {
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "contacts",
                schema: "accounts",
                columns: table => new
                {
                    contact_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contacts", x => new { x.contact_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_contacts_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "accounts",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profiles",
                schema: "accounts",
                columns: table => new
                {
                    profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    avatar = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_profiles", x => new { x.profile_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_profiles_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "accounts",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "security",
                schema: "accounts",
                columns: table => new
                {
                    security_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    password = table.Column<byte[]>(type: "bytea", nullable: false),
                    salt = table.Column<byte[]>(type: "bytea", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_security", x => new { x.security_id, x.user_id });
                    table.ForeignKey(
                        name: "fk_security_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "accounts",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_contacts_user_id",
                schema: "accounts",
                table: "contacts",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_profiles_user_id",
                schema: "accounts",
                table: "profiles",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_security_user_id",
                schema: "accounts",
                table: "security",
                column: "user_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "categories",
                schema: "common");

            migrationBuilder.DropTable(
                name: "contacts",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "products",
                schema: "common");

            migrationBuilder.DropTable(
                name: "profiles",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "security",
                schema: "accounts");

            migrationBuilder.DropTable(
                name: "users",
                schema: "accounts");
        }
    }
}
