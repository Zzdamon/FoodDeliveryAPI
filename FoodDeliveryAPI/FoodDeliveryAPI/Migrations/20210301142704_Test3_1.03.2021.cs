using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDeliveryAPI.Migrations
{
    public partial class Test3_1032021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    tagId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.tagId);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTag",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false),
                    TagId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTag", x => new { x.RestaurantId, x.TagId });
                    table.ForeignKey(
                        name: "FK_RestaurantTag_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "tagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTag_TagId",
                table: "RestaurantTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RestaurantTag");

            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
