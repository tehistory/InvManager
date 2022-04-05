using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InvManager.Migrations
{
    public partial class TestBuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountID", "email", "password", "userName" },
                values: new object[] { 1, "ftegelhoff@gmail.com", "adminpassword1", "admin" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "accountID", "email", "password", "userName" },
                values: new object[] { 2, "", "password", "test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "accountID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "accountID",
                keyValue: 2);
        }
    }
}
