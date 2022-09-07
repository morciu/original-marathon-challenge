using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class manytomanyusermarathon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarathonUser_Users_MembersId",
                table: "MarathonUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarathonUser",
                table: "MarathonUser");

            migrationBuilder.RenameColumn(
                name: "MembersId",
                table: "MarathonUser",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_MarathonUser_MembersId",
                table: "MarathonUser",
                newName: "IX_MarathonUser_UserId");

            migrationBuilder.AddColumn<int>(
                name: "MarathonId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MarathonUser",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarathonUser",
                table: "MarathonUser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MarathonId",
                table: "Users",
                column: "MarathonId");

            migrationBuilder.CreateIndex(
                name: "IX_MarathonUser_MarathonId",
                table: "MarathonUser",
                column: "MarathonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MarathonUser_Users_UserId",
                table: "MarathonUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Marathons_MarathonId",
                table: "Users",
                column: "MarathonId",
                principalTable: "Marathons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarathonUser_Users_UserId",
                table: "MarathonUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Marathons_MarathonId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MarathonId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MarathonUser",
                table: "MarathonUser");

            migrationBuilder.DropIndex(
                name: "IX_MarathonUser_MarathonId",
                table: "MarathonUser");

            migrationBuilder.DropColumn(
                name: "MarathonId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MarathonUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MarathonUser",
                newName: "MembersId");

            migrationBuilder.RenameIndex(
                name: "IX_MarathonUser_UserId",
                table: "MarathonUser",
                newName: "IX_MarathonUser_MembersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarathonUser",
                table: "MarathonUser",
                columns: new[] { "MarathonId", "MembersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MarathonUser_Users_MembersId",
                table: "MarathonUser",
                column: "MembersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
