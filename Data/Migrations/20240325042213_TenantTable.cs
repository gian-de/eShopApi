using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace eShopApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class TenantTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_ProductVariants_product_variant_id",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariants_Products_product_id",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductVariants",
                table: "ProductVariants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "product");

            migrationBuilder.RenameTable(
                name: "ProductVariants",
                newName: "product_variant");

            migrationBuilder.RenameTable(
                name: "ProductImages",
                newName: "product_images");

            migrationBuilder.RenameIndex(
                name: "IX_ProductVariants_product_id",
                table: "product_variant",
                newName: "IX_product_variant_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductImages_product_variant_id",
                table: "product_images",
                newName: "IX_product_images_product_variant_id");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_product",
                table: "product",
                column: "product_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_variant",
                table: "product_variant",
                column: "variant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_images",
                table: "product_images",
                column: "image_id");

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    tenant_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tenant_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.tenant_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_TenantId",
                table: "product",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_tenant_TenantId",
                table: "product",
                column: "TenantId",
                principalTable: "tenant",
                principalColumn: "tenant_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_images_product_variant_product_variant_id",
                table: "product_images",
                column: "product_variant_id",
                principalTable: "product_variant",
                principalColumn: "variant_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_variant_product_product_id",
                table: "product_variant",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_tenant_TenantId",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_images_product_variant_product_variant_id",
                table: "product_images");

            migrationBuilder.DropForeignKey(
                name: "FK_product_variant_product_product_id",
                table: "product_variant");

            migrationBuilder.DropTable(
                name: "tenant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_variant",
                table: "product_variant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_images",
                table: "product_images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_TenantId",
                table: "product");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "product");

            migrationBuilder.RenameTable(
                name: "product_variant",
                newName: "ProductVariants");

            migrationBuilder.RenameTable(
                name: "product_images",
                newName: "ProductImages");

            migrationBuilder.RenameTable(
                name: "product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_product_variant_product_id",
                table: "ProductVariants",
                newName: "IX_ProductVariants_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_images_product_variant_id",
                table: "ProductImages",
                newName: "IX_ProductImages_product_variant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductVariants",
                table: "ProductVariants",
                column: "variant_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductImages",
                table: "ProductImages",
                column: "image_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_ProductVariants_product_variant_id",
                table: "ProductImages",
                column: "product_variant_id",
                principalTable: "ProductVariants",
                principalColumn: "variant_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariants_Products_product_id",
                table: "ProductVariants",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
