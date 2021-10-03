using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettAPI.Migrations
{
    public partial class AddBettToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Bett",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "Odds",
                table: "Bett",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated",
                table: "Bett",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "UpdatedBett",
                table: "Bett",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odds",
                table: "Bett");

            migrationBuilder.DropColumn(
                name: "Updated",
                table: "Bett");

            migrationBuilder.DropColumn(
                name: "UpdatedBett",
                table: "Bett");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Bett",
                newName: "Name");
        }
    }
}
