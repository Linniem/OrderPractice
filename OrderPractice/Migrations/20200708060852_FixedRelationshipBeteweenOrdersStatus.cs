using Microsoft.EntityFrameworkCore.Migrations;

namespace OrderPractice.Migrations
{
    public partial class FixedRelationshipBeteweenOrdersStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StatusId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StatusId",
                table: "Products",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Statuses_StatusId",
                table: "Products",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
