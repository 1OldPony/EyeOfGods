using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class TerrPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PareWhithPoint",
                table: "Terrain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointHeight",
                table: "Terrain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointNumber",
                table: "Terrain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointWidth",
                table: "Terrain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XCoordinate",
                table: "Terrain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YCoordinate",
                table: "Terrain",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PareWhithPoint",
                table: "InterestPoint",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointHeight",
                table: "InterestPoint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointNumber",
                table: "InterestPoint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointWidth",
                table: "InterestPoint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XCoordinate",
                table: "InterestPoint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YCoordinate",
                table: "InterestPoint",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PareWhithPoint",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "PointHeight",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "PointNumber",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "PointWidth",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "YCoordinate",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "PareWhithPoint",
                table: "InterestPoint");

            migrationBuilder.DropColumn(
                name: "PointHeight",
                table: "InterestPoint");

            migrationBuilder.DropColumn(
                name: "PointNumber",
                table: "InterestPoint");

            migrationBuilder.DropColumn(
                name: "PointWidth",
                table: "InterestPoint");

            migrationBuilder.DropColumn(
                name: "XCoordinate",
                table: "InterestPoint");

            migrationBuilder.DropColumn(
                name: "YCoordinate",
                table: "InterestPoint");
        }
    }
}
