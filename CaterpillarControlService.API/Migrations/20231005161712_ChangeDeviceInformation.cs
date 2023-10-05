using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaterpillarControlService.API.Migrations
{
    public partial class ChangeDeviceInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_AspNetUsers_RiderId",
                table: "Shifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_ControlStations_ControlStationId",
                table: "Shifts");

            migrationBuilder.DropForeignKey(
                name: "FK_Spices_Shifts_ShiftId",
                table: "Spices");

            migrationBuilder.DropTable(
                name: "GECADeviceInformation");

            migrationBuilder.DropIndex(
                name: "IX_Spices_ShiftId",
                table: "Spices");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_ControlStationId",
                table: "Shifts");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_RiderId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "Spices");

            migrationBuilder.DropColumn(
                name: "ControlStationId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "RiderId",
                table: "Shifts");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Shifts",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DeviceInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batteryPercentage = table.Column<double>(type: "float", nullable: false),
                    deviceId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceInformations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DeviceInformations",
                columns: new[] { "Id", "batteryPercentage", "deviceId" },
                values: new object[] { 1L, 90.0, "1" });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_UserId",
                table: "Shifts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_AspNetUsers_UserId",
                table: "Shifts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_AspNetUsers_UserId",
                table: "Shifts");

            migrationBuilder.DropTable(
                name: "DeviceInformations");

            migrationBuilder.DropIndex(
                name: "IX_Shifts_UserId",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shifts");

            migrationBuilder.AddColumn<long>(
                name: "ShiftId",
                table: "Spices",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ControlStationId",
                table: "Shifts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "RiderId",
                table: "Shifts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "GECADeviceInformation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    batteryPercentage = table.Column<double>(type: "float", nullable: false),
                    deviceId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GECADeviceInformation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GECADeviceInformation",
                columns: new[] { "Id", "batteryPercentage", "deviceId" },
                values: new object[] { 1L, 90.0, "1" });

            migrationBuilder.CreateIndex(
                name: "IX_Spices_ShiftId",
                table: "Spices",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_ControlStationId",
                table: "Shifts",
                column: "ControlStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_RiderId",
                table: "Shifts",
                column: "RiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_AspNetUsers_RiderId",
                table: "Shifts",
                column: "RiderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_ControlStations_ControlStationId",
                table: "Shifts",
                column: "ControlStationId",
                principalTable: "ControlStations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Spices_Shifts_ShiftId",
                table: "Spices",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id");
        }
    }
}
