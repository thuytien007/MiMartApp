using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class EditFKKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_StoreDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId_StoreId",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_StoreId_ProductId",
                table: "OrderDetails",
                columns: new[] { "StoreId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_StoreDetails",
                table: "OrderDetails",
                columns: new[] { "StoreId", "ProductId" },
                principalTable: "StoreDetails",
                principalColumns: new[] { "StoreId", "ProductId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_StoreDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_StoreId_ProductId",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId_StoreId",
                table: "OrderDetails",
                columns: new[] { "ProductId", "StoreId" });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_StoreDetails",
                table: "OrderDetails",
                columns: new[] { "ProductId", "StoreId" },
                principalTable: "StoreDetails",
                principalColumns: new[] { "StoreId", "ProductId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
