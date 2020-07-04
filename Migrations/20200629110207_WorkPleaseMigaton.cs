using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PleaseWorkDamnIt.Migrations
{
    public partial class WorkPleaseMigaton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    TypeOfService = table.Column<string>(nullable: true),
                    PurchasingDate = table.Column<DateTime>(nullable: false),
                    NumberOfWorkingDays = table.Column<int>(nullable: false),
                    NumberOfFailures = table.Column<int>(nullable: false),
                    DownTime = table.Column<int>(nullable: false),
                    Safety = table.Column<int>(nullable: true),
                    Function = table.Column<int>(nullable: true),
                    Area = table.Column<int>(nullable: true),
                    ServiceCost = table.Column<float>(nullable: false),
                    OperationCost = table.Column<float>(nullable: false),
                    PurchasingCost = table.Column<decimal>(type: "decimal (18,2)", nullable: false),
                    Detection = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Device");
        }
    }
}
