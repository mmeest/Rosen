using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rosen.Data.Migrations
{
    /// <inheritdoc />
    public partial class DartsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Darts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player1Points = table.Column<int>(type: "int", nullable: true),
                    Player2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player2Points = table.Column<int>(type: "int", nullable: true),
                    Player3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player3Points = table.Column<int>(type: "int", nullable: true),
                    Player4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player4Points = table.Column<int>(type: "int", nullable: true),
                    Player5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player5Points = table.Column<int>(type: "int", nullable: true),
                    Player6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player6Points = table.Column<int>(type: "int", nullable: true),
                    Player7 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player7Points = table.Column<int>(type: "int", nullable: true),
                    Player8 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Player8Points = table.Column<int>(type: "int", nullable: true),
                    TopPoints = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Darts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Darts");

            migrationBuilder.RenameColumn(
                name: "FLName",
                table: "AspNetUsers",
                newName: "ApplicationUserName");
        }
    }
}
