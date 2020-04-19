using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ValeIotApi.Migrations
{
    public partial class Intialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sensors",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DeviceTypeId = table.Column<int>(nullable: false),
                    LocationId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DeviceTypeId1 = table.Column<long>(nullable: true),
                    LocationId1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensors_DeviceTypes_DeviceTypeId1",
                        column: x => x.DeviceTypeId1,
                        principalTable: "DeviceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sensors_Locations_LocationId1",
                        column: x => x.LocationId1,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SensorMeasurements",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SensorId = table.Column<long>(nullable: false),
                    MeasurementTypeId = table.Column<long>(nullable: false),
                    LocationId = table.Column<long>(nullable: false),
                    MeasuredValue = table.Column<decimal>(nullable: false),
                    RawData = table.Column<string>(nullable: false),
                    MeasuredDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorMeasurements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorMeasurements_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorMeasurements_MeasurementTypes_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorMeasurements_Sensors_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorMeasurements_LocationId",
                table: "SensorMeasurements",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorMeasurements_MeasurementTypeId",
                table: "SensorMeasurements",
                column: "MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorMeasurements_SensorId",
                table: "SensorMeasurements",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_DeviceTypeId1",
                table: "Sensors",
                column: "DeviceTypeId1");

            migrationBuilder.CreateIndex(
                name: "IX_Sensors_LocationId1",
                table: "Sensors",
                column: "LocationId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorMeasurements");

            migrationBuilder.DropTable(
                name: "MeasurementTypes");

            migrationBuilder.DropTable(
                name: "Sensors");

            migrationBuilder.DropTable(
                name: "DeviceTypes");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
