using Microsoft.EntityFrameworkCore.Migrations;

namespace OkkApi.Migrations
{
    public partial class KRCEditRelationShipone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "RecordId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserId",
                table: "Users",
                newName: "IX_Users_RecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Records_RecordId",
                table: "Users",
                column: "RecordId",
                principalTable: "Records",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Records_RecordId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "RecordId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_RecordId",
                table: "Users",
                newName: "IX_Users_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_UserId",
                table: "Users",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
