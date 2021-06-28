using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShoppingDbContext.Migrations
{
    public partial class MemberTableIdUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberProducts_Members_MemberId",
                table: "MemberProducts");

            migrationBuilder.DropIndex(
                name: "IX_MemberProducts_MemberId",
                table: "MemberProducts");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "MemberProducts");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MemberProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "MemberProducts",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MemberProducts_AspNetUsers_UserId1",
                table: "MemberProducts");

            migrationBuilder.DropIndex(
                name: "IX_MemberProducts_UserId1",
                table: "MemberProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MemberProducts");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "MemberProducts");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "MemberProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MemberProducts_MemberId",
                table: "MemberProducts",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_MemberProducts_Members_MemberId",
                table: "MemberProducts",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
