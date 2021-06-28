using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingDbContext.Migrations
{
    public partial class addAvailablecountToisStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableCount",
                table: "Products");

            migrationBuilder.AddColumn<bool>(
                name: "IsOutOfStock",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOutOfStock",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "AvailableCount",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
