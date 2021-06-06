using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryAPI.Migrations
{
    public partial class Test6_6_21_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Couriers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Couriers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Clients",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Couriers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Couriers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Clients",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Clients",
                newName: "Name");
        }
    }
}
