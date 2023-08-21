using Microsoft.EntityFrameworkCore.Migrations;

namespace EyeOfGods.Migrations
{
    public partial class ShieldRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Shields_ShiedId",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "ShiedId",
                table: "Units",
                newName: "ShieldId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_ShiedId",
                table: "Units",
                newName: "IX_Units_ShieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Shields_ShieldId",
                table: "Units",
                column: "ShieldId",
                principalTable: "Shields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Units_Shields_ShieldId",
                table: "Units");

            migrationBuilder.RenameColumn(
                name: "ShieldId",
                table: "Units",
                newName: "ShiedId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_ShieldId",
                table: "Units",
                newName: "IX_Units_ShiedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Shields_ShiedId",
                table: "Units",
                column: "ShiedId",
                principalTable: "Shields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
