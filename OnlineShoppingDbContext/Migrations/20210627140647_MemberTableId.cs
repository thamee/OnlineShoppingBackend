using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingDbContext.Migrations
{
    public partial class MemberTableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberProducts_AspNetUsers_UserId1",
                table: "MemberProducts");

            migrationBuilder.DropIndex(
                name: "IX_MemberProducts_UserId1",
                table: "MemberProducts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MemberProducts");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "MemberProducts",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_MemberProducts_UserId",
                table: "MemberProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProducts_AspNetUsers_UserId",
                table: "MemberProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberProducts_AspNetUsers_UserId",
                table: "MemberProducts");

            migrationBuilder.DropIndex(
                name: "IX_MemberProducts_UserId",
                table: "MemberProducts");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "MemberProducts",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MemberProducts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberProducts_UserId1",
                table: "MemberProducts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProducts_AspNetUsers_UserId1",
                table: "MemberProducts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
