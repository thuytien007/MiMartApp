using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class ChangOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_OrderDtails_StoreDetails",
                table: "OrderDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_StoreDetails",
                table: "OrderDetails",
                columns: new[] { "ProductId", "StoreId" },
                principalTable: "StoreDetails",
                principalColumns: new[] { "StoreId", "ProductId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_StoreDetails",
                table: "OrderDetails");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_OrderDtails_StoreDetails",
                table: "OrderDetails",
                columns: new[] { "ProductId", "StoreId" },
                principalTable: "StoreDetails",
                principalColumns: new[] { "StoreId", "ProductId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
