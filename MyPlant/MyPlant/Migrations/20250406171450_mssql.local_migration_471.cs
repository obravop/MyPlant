using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPlant.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_471 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlantLocationId",
                table: "Plant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PlantLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantLocation", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_PlantLocationId",
                table: "Plant",
                column: "PlantLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plant_PlantLocation_PlantLocationId",
                table: "Plant",
                column: "PlantLocationId",
                principalTable: "PlantLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plant_PlantLocation_PlantLocationId",
                table: "Plant");

            migrationBuilder.DropTable(
                name: "PlantLocation");

            migrationBuilder.DropIndex(
                name: "IX_Plant_PlantLocationId",
                table: "Plant");

            migrationBuilder.DropColumn(
                name: "PlantLocationId",
                table: "Plant");
        }
    }
}
