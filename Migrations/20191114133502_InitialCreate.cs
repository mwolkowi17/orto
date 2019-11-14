using Microsoft.EntityFrameworkCore.Migrations;

namespace Orto.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BazaSlow",
                columns: table => new
                {
                    przykladyId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    przykladSample = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BazaSlow", x => x.przykladyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BazaSlow");
        }
    }
}
