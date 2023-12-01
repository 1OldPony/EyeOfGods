using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class MSchImp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Map");

            migrationBuilder.AddColumn<int>(
                name: "ReferenceTo",
                table: "Terrain",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxDensityAvail",
                table: "MapSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceTo",
                table: "MapSchemePoint",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReferenceTo",
                table: "InterestPoint",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceTo",
                table: "Terrain");

            migrationBuilder.DropColumn(
                name: "MaxDensityAvail",
                table: "MapSchemes");

            migrationBuilder.DropColumn(
                name: "ReferenceTo",
                table: "MapSchemePoint");

            migrationBuilder.DropColumn(
                name: "ReferenceTo",
                table: "InterestPoint");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Map",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
