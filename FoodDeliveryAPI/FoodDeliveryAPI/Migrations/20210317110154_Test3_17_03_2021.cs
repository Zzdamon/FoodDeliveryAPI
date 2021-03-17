using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryAPI.Migrations
{
    public partial class Test3_17_03_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Restaurants_restaurantId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_categId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_restaurantId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Tag",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "banner",
                table: "Tag",
                newName: "Banner");

            migrationBuilder.RenameColumn(
                name: "tagId",
                table: "Tag",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "restaurantLng",
                table: "Restaurants",
                newName: "RestaurantLng");

            migrationBuilder.RenameColumn(
                name: "restaurantLat",
                table: "Restaurants",
                newName: "RestaurantLat");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Restaurants",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "minOrder",
                table: "Restaurants",
                newName: "MinOrder");

            migrationBuilder.RenameColumn(
                name: "logo",
                table: "Restaurants",
                newName: "Logo");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Restaurants",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Restaurants",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Restaurants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "stage",
                table: "Orders",
                newName: "Stage");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "Orders",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "orderNotes",
                table: "Orders",
                newName: "OrderNotes");

            migrationBuilder.RenameColumn(
                name: "deliveryLng",
                table: "Orders",
                newName: "DeliveryLng");

            migrationBuilder.RenameColumn(
                name: "deliveryLat",
                table: "Orders",
                newName: "DeliveryLat");

            migrationBuilder.RenameColumn(
                name: "deliveryAddress",
                table: "Orders",
                newName: "DeliveryAddress");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_restaurantId",
                table: "Orders",
                newName: "IX_Orders_RestaurantId");

            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "OrderItems",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "OrderItems",
                newName: "ItemId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Items",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Items",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "categId",
                table: "Items",
                newName: "CategId");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "Items",
                newName: "ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_categId",
                table: "Items",
                newName: "IX_Items_CategId");

            migrationBuilder.RenameColumn(
                name: "restaurantId",
                table: "Categories",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "categId",
                table: "Categories",
                newName: "CategId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_restaurantId",
                table: "Categories",
                newName: "IX_Categories_RestaurantId");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourierId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    CourierId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.CourierId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourierId",
                table: "Orders",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_Email",
                table: "Couriers",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Restaurants_RestaurantId",
                table: "Categories",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_CategId",
                table: "Items",
                column: "CategId",
                principalTable: "Categories",
                principalColumn: "CategId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders",
                column: "CourierId",
                principalTable: "Couriers",
                principalColumn: "CourierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Restaurants_RestaurantId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Categories_CategId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Couriers_CourierId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Restaurants_RestaurantId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ClientId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CourierId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CourierId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Tag",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Banner",
                table: "Tag",
                newName: "banner");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tag",
                newName: "tagId");

            migrationBuilder.RenameColumn(
                name: "RestaurantLng",
                table: "Restaurants",
                newName: "restaurantLng");

            migrationBuilder.RenameColumn(
                name: "RestaurantLat",
                table: "Restaurants",
                newName: "restaurantLat");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Restaurants",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MinOrder",
                table: "Restaurants",
                newName: "minOrder");

            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Restaurants",
                newName: "logo");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Restaurants",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Restaurants",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Restaurants",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Stage",
                table: "Orders",
                newName: "stage");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Orders",
                newName: "restaurantId");

            migrationBuilder.RenameColumn(
                name: "OrderNotes",
                table: "Orders",
                newName: "orderNotes");

            migrationBuilder.RenameColumn(
                name: "DeliveryLng",
                table: "Orders",
                newName: "deliveryLng");

            migrationBuilder.RenameColumn(
                name: "DeliveryLat",
                table: "Orders",
                newName: "deliveryLat");

            migrationBuilder.RenameColumn(
                name: "DeliveryAddress",
                table: "Orders",
                newName: "deliveryAddress");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_RestaurantId",
                table: "Orders",
                newName: "IX_Orders_restaurantId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderItems",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "OrderItems",
                newName: "itemId");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Items",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "CategId",
                table: "Items",
                newName: "categId");

            migrationBuilder.RenameColumn(
                name: "ItemId",
                table: "Items",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CategId",
                table: "Items",
                newName: "IX_Items_categId");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Categories",
                newName: "restaurantId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CategId",
                table: "Categories",
                newName: "categId");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_RestaurantId",
                table: "Categories",
                newName: "IX_Categories_restaurantId");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accountType = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    defaultAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userId",
                table: "Orders",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_email",
                table: "Users",
                column: "email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Restaurants_restaurantId",
                table: "Categories",
                column: "restaurantId",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Categories_categId",
                table: "Items",
                column: "categId",
                principalTable: "Categories",
                principalColumn: "categId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Restaurants_restaurantId",
                table: "Orders",
                column: "restaurantId",
                principalTable: "Restaurants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_userId",
                table: "Orders",
                column: "userId",
                principalTable: "Users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
