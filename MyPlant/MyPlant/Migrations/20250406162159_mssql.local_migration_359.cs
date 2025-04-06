using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyPlant.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_359 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlantType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plant",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WateringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plant_PlantType_PlantTypeId",
                        column: x => x.PlantTypeId,
                        principalTable: "PlantType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plant_PlantTypeId",
                table: "Plant",
                column: "PlantTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plant");

            migrationBuilder.DropTable(
                name: "PlantType");
        }
    }
}
