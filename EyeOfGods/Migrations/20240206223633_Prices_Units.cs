using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class Prices_Units : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreakPoint",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Damage",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vigor",
                table: "Units",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakPoint",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Damage",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Vigor",
                table: "Units");
        }
    }
}
