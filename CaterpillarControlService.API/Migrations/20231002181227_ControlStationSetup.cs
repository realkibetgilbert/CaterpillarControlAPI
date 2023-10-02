using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaterpillarControlService.API.Migrations
{
    public partial class ControlStationSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ControlStations",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ControlStations");
        }
    }
}
