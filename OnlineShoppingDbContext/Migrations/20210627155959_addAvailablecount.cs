using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingDbContext.Migrations
{
    public partial class addAvailablecount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableCount",
                table: "Products",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCount",
                table: "Products");
        }
    }
}
