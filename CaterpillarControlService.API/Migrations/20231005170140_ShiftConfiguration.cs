using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaterpillarControlService.API.Migrations
{
    public partial class ShiftConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "CreatedAt", "EndedAt", "IsActive", "UserId" },
                values: new object[] { 1L, new DateTime(2023, 10, 5, 17, 1, 40, 171, DateTimeKind.Utc).AddTicks(1051), null, true, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shifts",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
