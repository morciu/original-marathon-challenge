using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Marathonrepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarathonUser_Marathon_MarathonId",
                table: "MarathonUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marathon",
                table: "Marathon");

            migrationBuilder.RenameTable(
                name: "Marathon",
                newName: "Marathons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marathons",
                table: "Marathons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarathonUser_Marathons_MarathonId",
                table: "MarathonUser",
                column: "MarathonId",
                principalTable: "Marathons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarathonUser_Marathons_MarathonId",
                table: "MarathonUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Marathons",
                table: "Marathons");

            migrationBuilder.RenameTable(
                name: "Marathons",
                newName: "Marathon");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Marathon",
                table: "Marathon",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MarathonUser_Marathon_MarathonId",
                table: "MarathonUser",
                column: "MarathonId",
                principalTable: "Marathon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
