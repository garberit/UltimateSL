using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UltimateShoppingList.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivitiesTable",
                columns: table => new
                {
                    ActivityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActivityDate = table.Column<DateTime>(nullable: false),
                    ActivityDescription = table.Column<string>(nullable: true),
                    ActivityShoppingListID = table.Column<int>(nullable: false),
                    ActivityUserID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: true),
                    UserID = table.Column<int>(nullable: true),
                    GroupsGroupID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.ActivityID);
                });

            migrationBuilder.CreateTable(
                name: "ProductsTable",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    ProductCategory = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<decimal>(nullable: false),
                    ProductPickedUp = table.Column<bool>(nullable: false),
                    ProductNotes = table.Column<string>(nullable: true),
                    ProductQuantity = table.Column<int>(nullable: false),
                    ProductCreationDate = table.Column<DateTime>(nullable: false),
                    ProductCreatedByUserID = table.Column<int>(nullable: true),
                    ProductSharedWithGroupID = table.Column<int>(nullable: true),
                    ShoppingListID = table.Column<int>(nullable: false),
                    ShoppingListShopListID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingListsTable",
                columns: table => new
                {
                    ShopListID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopListName = table.Column<string>(nullable: true),
                    ShopListUsersGroupID = table.Column<int>(nullable: true),
                    ShopListCreatedDate = table.Column<DateTime>(nullable: false),
                    ShopListEmailAddressOfOwner = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingLists", x => x.ShopListID);
                });

            migrationBuilder.CreateTable(
                name: "UsersTable",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: true),
                    UserEMail = table.Column<string>(nullable: true),
                    UserAddress = table.Column<string>(nullable: true),
                    UserFirstName = table.Column<string>(nullable: true),
                    UserLastName = table.Column<string>(nullable: true),
                    GroupsGroupID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "GroupsTable",
                columns: table => new
                {
                    GroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(nullable: true),
                    GroupCategory = table.Column<int>(nullable: false),
                    GroupCreatedDate = table.Column<DateTime>(nullable: false),
                    GroupCreatedByUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                    table.ForeignKey(
                        name: "FK_GroupsTable_UsersTable_GroupCreatedByUser",
                        column: x => x.GroupCreatedByUser,
                        principalTable: "UsersTable",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesTable_ActivityShoppingListID",
                table: "ActivitiesTable",
                column: "ActivityShoppingListID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesTable_GroupsGroupID",
                table: "ActivitiesTable",
                column: "GroupsGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesTable_ProductID",
                table: "ActivitiesTable",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivitiesTable_UserID",
                table: "ActivitiesTable",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupsTable_GroupCreatedByUser",
                table: "GroupsTable",
                column: "GroupCreatedByUser");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_ProductCreatedByUserID",
                table: "ProductsTable",
                column: "ProductCreatedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_ProductSharedWithGroupID",
                table: "ProductsTable",
                column: "ProductSharedWithGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_ShoppingListID",
                table: "ProductsTable",
                column: "ShoppingListID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsTable_ShoppingListShopListID",
                table: "ProductsTable",
                column: "ShoppingListShopListID");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingListsTable_ShopListUsersGroupID",
                table: "ShoppingListsTable",
                column: "ShopListUsersGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_UsersTable_GroupsGroupID",
                table: "UsersTable",
                column: "GroupsGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesTable_ShoppingListsTable_ActivityShoppingListID",
                table: "ActivitiesTable",
                column: "ActivityShoppingListID",
                principalTable: "ShoppingListsTable",
                principalColumn: "ShopListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesTable_GroupsTable_GroupsGroupID",
                table: "ActivitiesTable",
                column: "GroupsGroupID",
                principalTable: "GroupsTable",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesTable_ProductsTable_ProductID",
                table: "ActivitiesTable",
                column: "ProductID",
                principalTable: "ProductsTable",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivitiesTable_UsersTable_UserID",
                table: "ActivitiesTable",
                column: "UserID",
                principalTable: "UsersTable",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_ShoppingListsTable_ShoppingListID",
                table: "ProductsTable",
                column: "ShoppingListID",
                principalTable: "ShoppingListsTable",
                principalColumn: "ShopListID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_ShoppingListsTable_ShoppingListShopListID",
                table: "ProductsTable",
                column: "ShoppingListShopListID",
                principalTable: "ShoppingListsTable",
                principalColumn: "ShopListID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_GroupsTable_ProductSharedWithGroupID",
                table: "ProductsTable",
                column: "ProductSharedWithGroupID",
                principalTable: "GroupsTable",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsTable_UsersTable_ProductCreatedByUserID",
                table: "ProductsTable",
                column: "ProductCreatedByUserID",
                principalTable: "UsersTable",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingListsTable_GroupsTable_ShopListUsersGroupID",
                table: "ShoppingListsTable",
                column: "ShopListUsersGroupID",
                principalTable: "GroupsTable",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersTable_GroupsTable_GroupsGroupID",
                table: "UsersTable",
                column: "GroupsGroupID",
                principalTable: "GroupsTable",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersTable_GroupsTable_GroupsGroupID",
                table: "UsersTable");

            migrationBuilder.DropTable(
                name: "ActivitiesTable");

            migrationBuilder.DropTable(
                name: "ProductsTable");

            migrationBuilder.DropTable(
                name: "ShoppingListsTable");

            migrationBuilder.DropTable(
                name: "GroupsTable");

            migrationBuilder.DropTable(
                name: "UsersTable");
        }
    }
}
