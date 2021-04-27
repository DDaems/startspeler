using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartspelerMVC.Migrations
{
    public partial class UpdateDrakkaart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aantal_Verbruikt",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.AddColumn<DateTime>(
                name: "Aankoopdatum",
                schema: "SS",
                table: "Drankkaarten",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Aantal_beschikbaar",
                schema: "SS",
                table: "Drankkaarten",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                schema: "SS",
                table: "Drankkaarten",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Aankoopdatum",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.DropColumn(
                name: "Aantal_beschikbaar",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "SS",
                table: "Drankkaarten");

            migrationBuilder.AddColumn<int>(
                name: "Aantal_Verbruikt",
                schema: "SS",
                table: "Drankkaarten",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
