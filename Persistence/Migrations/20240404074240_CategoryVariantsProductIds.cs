using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryVariantsProductIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product_id",
                schema: "category_schema");

            migrationBuilder.DropPrimaryKey(
                name: "pk_variants",
                schema: "product_schema",
                table: "variants");

            migrationBuilder.DropIndex(
                name: "ix_variants_product_id",
                schema: "product_schema",
                table: "variants");

            migrationBuilder.DropPrimaryKey(
                name: "pk_publish_variants",
                schema: "category_schema",
                table: "publish_variants");

            migrationBuilder.DropIndex(
                name: "ix_publish_variants_category_id",
                schema: "category_schema",
                table: "publish_variants");

            migrationBuilder.AddPrimaryKey(
                name: "pk_variants",
                schema: "product_schema",
                table: "variants",
                columns: new[] { "product_id", "variant_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_publish_variants",
                schema: "category_schema",
                table: "publish_variants",
                columns: new[] { "category_id", "publish_variant_id" });

            migrationBuilder.CreateTable(
                name: "publish_variant_items",
                schema: "category_schema",
                columns: table => new
                {
                    publish_variant_item_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    publish_variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_publish_variant_items", x => new { x.publish_variant_item_id, x.category_id, x.publish_variant_id });
                    table.ForeignKey(
                        name: "fk_publish_variant_items_publish_variants_category_id_publish_",
                        columns: x => new { x.category_id, x.publish_variant_id },
                        principalSchema: "category_schema",
                        principalTable: "publish_variants",
                        principalColumns: new[] { "category_id", "publish_variant_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_publish_variant_items_category_id_publish_variant_id",
                schema: "category_schema",
                table: "publish_variant_items",
                columns: new[] { "category_id", "publish_variant_id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "publish_variant_items",
                schema: "category_schema");

            migrationBuilder.DropPrimaryKey(
                name: "pk_variants",
                schema: "product_schema",
                table: "variants");

            migrationBuilder.DropPrimaryKey(
                name: "pk_publish_variants",
                schema: "category_schema",
                table: "publish_variants");

            migrationBuilder.AddPrimaryKey(
                name: "pk_variants",
                schema: "product_schema",
                table: "variants",
                columns: new[] { "variant_id", "product_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_publish_variants",
                schema: "category_schema",
                table: "publish_variants",
                columns: new[] { "publish_variant_id", "category_id" });

            migrationBuilder.CreateTable(
                name: "product_id",
                schema: "category_schema",
                columns: table => new
                {
                    publish_variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    publish_variantcategory_id = table.Column<Guid>(type: "uuid", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product_id", x => new { x.publish_variant_id, x.publish_variantcategory_id, x.id });
                    table.ForeignKey(
                        name: "fk_product_id_publish_variants_publish_variant_id_publish_vari",
                        columns: x => new { x.publish_variant_id, x.publish_variantcategory_id },
                        principalSchema: "category_schema",
                        principalTable: "publish_variants",
                        principalColumns: new[] { "publish_variant_id", "category_id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_variants_product_id",
                schema: "product_schema",
                table: "variants",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_publish_variants_category_id",
                schema: "category_schema",
                table: "publish_variants",
                column: "category_id");
        }
    }
}
