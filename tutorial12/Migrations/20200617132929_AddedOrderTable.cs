using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tutorial12.Migrations
{
    public partial class AddedOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAccepted = table.Column<DateTime>(type: "date", nullable: false),
                    DateFinished = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(maxLength: 255, nullable: false),
                    IdClient = table.Column<int>(nullable: false),
                    IdEmployee = table.Column<int>(nullable: false),
                    IdCustomerNavIdClient = table.Column<int>(nullable: true),
                    IdEmployeeNavIdEmployee = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Order_pk", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_Customer_IdCustomerNavIdClient",
                        column: x => x.IdCustomerNavIdClient,
                        principalTable: "Customer",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Employee_IdEmployeeNavIdEmployee",
                        column: x => x.IdEmployeeNavIdEmployee,
                        principalTable: "Employee",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdCustomerNavIdClient",
                table: "Order",
                column: "IdCustomerNavIdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdEmployeeNavIdEmployee",
                table: "Order",
                column: "IdEmployeeNavIdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
