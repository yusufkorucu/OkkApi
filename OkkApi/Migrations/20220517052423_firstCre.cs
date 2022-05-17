using Microsoft.EntityFrameworkCore.Migrations;

namespace OkkApi.Migrations
{
    public partial class firstCre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SpecialCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpecialStatus",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TCKNO",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DataPulse",
                table: "Records",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationTime",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HStatus",
                table: "Records",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpecialCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpecialStatus",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TCKNO",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DataPulse",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "DurationTime",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "HStatus",
                table: "Records");
        }
    }
}
