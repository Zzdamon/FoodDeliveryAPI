using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryAPI.Migrations
{
    public partial class Test_120321 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "restaurantLat",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "restaurantLng",
                table: "Restaurants",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "deliveryLat",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "deliveryLng",
                table: "Orders",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "restaurantLat",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "restaurantLng",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "deliveryLat",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "deliveryLng",
                table: "Orders");
        }
    }
}
