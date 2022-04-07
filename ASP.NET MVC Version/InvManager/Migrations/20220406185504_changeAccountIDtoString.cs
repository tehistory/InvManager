using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvManager.Migrations
{
    public partial class changeAccountIDtoString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "accountID",
                table: "Containers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Containers",
                keyColumn: "containerID",
                keyValue: 1,
                column: "accountID",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "accountID",
                table: "Containers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Containers",
                keyColumn: "containerID",
                keyValue: 1,
                column: "accountID",
                value: 1);
        }
    }
}
