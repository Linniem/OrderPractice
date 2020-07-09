using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderPractice.Migrations
{
    public partial class initModelAndSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    StatusId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    OrderProductId = table.Column<int>(nullable: false),
                    StatusCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Products_OrderProductId",
                        column: x => x.OrderProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Statuses_StatusCode",
                        column: x => x.StatusCode,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "StatusId" },
                values: new object[,]
                {
                    { 1, "Product1", null },
                    { 2, "Product2", null },
                    { 3, "Product3", null },
                    { 4, "Product4", null }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "StatusName" },
                values: new object[,]
                {
                    { 1, "Payment completed" },
                    { 2, "To be shipped" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "Cost", "OrderProductId", "Price", "StatusCode" },
                values: new object[,]
                {
                    { "A20202026001", 90, 1, 100, 1 },
                    { "A20202026002", 100, 2, 120, 1 },
                    { "A20202026003", 150, 3, 200, 1 },
                    { "A20202026004", 120, 4, 150, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderProductId",
                table: "Orders",
                column: "OrderProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusCode",
                table: "Orders",
                column: "StatusCode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
