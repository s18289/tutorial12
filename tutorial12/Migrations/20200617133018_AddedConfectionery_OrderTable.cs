using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial12.Migrations
{
    public partial class AddedConfectionery_OrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confectionery_Order",
                columns: table => new
                {
                    IdConfectionery = table.Column<int>(nullable: false),
                    IdOrder = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false, defaultValue: "None")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confectionery_Order", x => new { x.IdConfectionery, x.IdOrder });
                    table.ForeignKey(
                        name: "idConfectionery",
                        column: x => x.IdConfectionery,
                        principalTable: "Confectionery",
                        principalColumn: "IdConfectionery",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "idOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confectionery_Order_IdOrder",
                table: "Confectionery_Order",
                column: "IdOrder");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Confectionery_Order");
        }
    }
}
