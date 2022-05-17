using Microsoft.EntityFrameworkCore.Migrations;

namespace OkkApi.Migrations
{
    public partial class KRCEditRelationShiptwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Records_RecordId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RecordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RecordId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "Records",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_UsersId",
                table: "Records",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Users_UsersId",
                table: "Records",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Users_UsersId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_UsersId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Records");

            migrationBuilder.AddColumn<int>(
                name: "RecordId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RecordId",
                table: "Users",
                column: "RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Records_RecordId",
                table: "Users",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
