using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class TweakProductTableV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_tenant_tenant_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "product_variant_id",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "tenant_id",
                table: "product",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_product_tenant_tenant_id",
                table: "product",
                column: "tenant_id",
                principalTable: "tenant",
                principalColumn: "tenant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_tenant_tenant_id",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "tenant_id",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "product_variant_id",
                table: "product",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_product_tenant_tenant_id",
                table: "product",
                column: "tenant_id",
                principalTable: "tenant",
                principalColumn: "tenant_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
