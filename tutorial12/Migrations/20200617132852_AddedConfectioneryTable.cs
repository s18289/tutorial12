using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial12.Migrations
{
    public partial class AddedConfectioneryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionery",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    PricePerItem = table.Column<double>(nullable: false),
                    Type = table.Column<string>(maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Confectionery_pk", x => x.IdConfectionery);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery");
        }
    }
}
