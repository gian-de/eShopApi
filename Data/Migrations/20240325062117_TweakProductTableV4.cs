using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class TweakProductTableV4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "product_id",
                table: "tenant",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "product_variant_id",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "product_id",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "product_variant_id",
                table: "product");
        }
    }
}
