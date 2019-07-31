using Microsoft.EntityFrameworkCore.Migrations;

namespace XCoach.Migrations
{
    public partial class RemovedStreetAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e666f46c-d734-495a-a0e0-6449d7b592b0", "AQAAAAEAACcQAAAAEPyNaDmMRMM0bUJs466m/HyCKcHndnkUae6j1mV0hubwOq85/BnfROyidUtubt8dlQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "StreetAddress",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f875b5e4-85d5-46c9-baea-1f04d5af72bb", "AQAAAAEAACcQAAAAEMAx0bIcB0yA+OE2pVVcf9R8fykjIo6dbEvSoH1G99ANxp5rpr53xs9yj41C1yZaXQ==" });
        }
    }
}
