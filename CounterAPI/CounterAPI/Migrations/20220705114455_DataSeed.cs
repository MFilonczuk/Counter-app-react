using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CounterAPI.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Counts",
                columns: new[] { "Id", "CountNumber" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Counts",
                columns: new[] { "Id", "CountNumber" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Counts",
                columns: new[] { "Id", "CountNumber" },
                values: new object[] { 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Counts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Counts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Counts",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
