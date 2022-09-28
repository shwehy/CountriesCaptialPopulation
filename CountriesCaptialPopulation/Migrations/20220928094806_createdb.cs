using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountriesCaptialPopulation.Migrations
{
    public partial class createdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PopulationList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    year = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    countryCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PopulationList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PopulationList_countries_countryCode",
                        column: x => x.countryCode,
                        principalTable: "countries",
                        principalColumn: "Code");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PopulationList_countryCode",
                table: "PopulationList",
                column: "countryCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PopulationList");

            migrationBuilder.DropTable(
                name: "countries");
        }
    }
}
