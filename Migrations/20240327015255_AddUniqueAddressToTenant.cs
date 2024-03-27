using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eShopApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueAddressToTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "unique_address",
                table: "tenant",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_unique_address",
                table: "tenant",
                column: "unique_address",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tenant_unique_address",
                table: "tenant");

            migrationBuilder.DropColumn(
                name: "unique_address",
                table: "tenant");
        }
    }
}
