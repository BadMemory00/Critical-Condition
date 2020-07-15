using Microsoft.EntityFrameworkCore.Migrations;

namespace PleaseWorkDamnIt.Migrations
{
    public partial class AddDeviceScoreColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeviceScore",
                table: "Device",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceScore",
                table: "Device");
        }
    }
}
