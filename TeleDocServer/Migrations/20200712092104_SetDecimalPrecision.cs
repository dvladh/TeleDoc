using Microsoft.EntityFrameworkCore.Migrations;

namespace TeleDocServer.Migrations
{
    public partial class SetDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c16bd29f-0b35-46fe-ae5b-6bec268a368b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "da1930b9-2a48-4c82-bb78-6ebfbff4d5f3");

            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Patients",
                type: "decimal(16, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Patients",
                type: "decimal(16, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Weight",
                table: "Patients",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Height",
                table: "Patients",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(16, 2)");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "da1930b9-2a48-4c82-bb78-6ebfbff4d5f3", "cb9535b4-2e3c-4e1e-b67b-fbba8b5d1047", "Patient", "PATIENT" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c16bd29f-0b35-46fe-ae5b-6bec268a368b", "4e876d79-53ab-4b16-b662-baed04459d75", "Doctor", "DOCTOR" });
        }
    }
}
