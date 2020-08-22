using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleDocServer.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6dd1ae7d-e6e7-4319-8bfc-6d6250bd6389", "5173b13f-f636-4e6e-9c0f-939663589ce6", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb60fafa-ef75-4ac8-bdfc-31b94bd3a805", "0f790e74-9106-4fba-b395-eda5396ea318", "Doctor", "DOCTOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6dd1ae7d-e6e7-4319-8bfc-6d6250bd6389");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fb60fafa-ef75-4ac8-bdfc-31b94bd3a805");
        }
    }
}
