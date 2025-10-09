using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TI_Net_2025_DemoEntity.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderLineStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "OrderLines",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_LocationId",
                table: "Stock",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_MovementLocation_LocationId",
                table: "Stock",
                column: "LocationId",
                principalTable: "MovementLocation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_MovementLocation_LocationId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_LocationId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "OrderLines");
        }
    }
}
