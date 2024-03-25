using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class TweakProductTableV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_tenant_TenantId",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "product",
                newName: "tenant_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_TenantId",
                table: "product",
                newName: "IX_product_tenant_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_tenant_tenant_id",
                table: "product",
                column: "tenant_id",
                principalTable: "tenant",
                principalColumn: "tenant_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_tenant_tenant_id",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "tenant_id",
                table: "product",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_product_tenant_id",
                table: "product",
                newName: "IX_product_TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_tenant_TenantId",
                table: "product",
                column: "TenantId",
                principalTable: "tenant",
                principalColumn: "tenant_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
