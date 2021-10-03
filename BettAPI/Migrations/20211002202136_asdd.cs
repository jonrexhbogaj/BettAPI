using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettAPI.Migrations
{
    public partial class asdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedTime",
                table: "Bett",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "isUpdated",
                table: "Bett",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedTime",
                table: "Bett");

            migrationBuilder.DropColumn(
                name: "isUpdated",
                table: "Bett");
        }
    }
}
