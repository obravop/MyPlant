using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPlant.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_796 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "PlantType",
                newName: "ScientificName");

            migrationBuilder.AddColumn<string>(
                name: "CommonName",
                table: "PlantType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommonName",
                table: "PlantType");

            migrationBuilder.RenameColumn(
                name: "ScientificName",
                table: "PlantType",
                newName: "Name");
        }
    }
}
