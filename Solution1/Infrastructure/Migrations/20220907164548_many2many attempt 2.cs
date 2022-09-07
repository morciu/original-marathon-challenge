using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class many2manyattempt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarathonUser_Marathons_MarathonId",
                table: "MarathonUser");

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

            migrationBuilder.RenameColumn(
                name: "MarathonId",
                table: "MarathonUser",
                newName: "MarathonsId");

            migrationBuilder.RenameIndex(
                name: "IX_MarathonUser_UserId",
                table: "MarathonUser",
                newName: "IX_MarathonUser_MembersId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Distance",
                table: "Activities",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MarathonUser",
                table: "MarathonUser",
                columns: new[] { "MarathonsId", "MembersId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MarathonUser_Marathons_MarathonsId",
                table: "MarathonUser",
                column: "MarathonsId",
                principalTable: "Marathons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MarathonUser_Users_MembersId",
                table: "MarathonUser",
                column: "MembersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MarathonUser_Marathons_MarathonsId",
                table: "MarathonUser");

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

            migrationBuilder.RenameColumn(
                name: "MarathonsId",
                table: "MarathonUser",
                newName: "MarathonId");

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

            migrationBuilder.AlterColumn<decimal>(
                name: "Distance",
                table: "Activities",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
                name: "FK_MarathonUser_Marathons_MarathonId",
                table: "MarathonUser",
                column: "MarathonId",
                principalTable: "Marathons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
    }
}
