using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP_Bicicleteria.Migrations
{
    /// <inheritdoc />
    public partial class QuitarSupplierCodeyAgregarSupplierId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierCode",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
