using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateShoppingList.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsTable_ShoppingListsTable_ShoppingListShopListID",
                table: "ProductsTable");

            migrationBuilder.DropIndex(
                name: "IX_ProductsTable_ShoppingListShopListID",
                table: "ProductsTable");

            migrationBuilder.DropColumn(
                name: "ShoppingListShopListID",
                table: "ProductsTable");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingListShopListID",
                table: "ProductsTable",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_ShoppingListShopListID",
                table: "ProductsTable",
                column: "ShoppingListShopListID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_ShoppingListsTable_ShoppingListShopListID",
                table: "ProductsTable",
                column: "ShoppingListShopListID",
                principalTable: "ShoppingListsTable",
                principalColumn: "ShopListID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
