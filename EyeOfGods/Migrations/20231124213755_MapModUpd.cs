using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EyeOfGods.Migrations
{
    /// <inheritdoc />
    public partial class MapModUpd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPoint_Quest_QuestId",
                table: "InterestPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quest",
                table: "Quest");

            migrationBuilder.RenameTable(
                name: "Quest",
                newName: "Quests");

            migrationBuilder.AddColumn<int>(
                name: "QuestLevel",
                table: "MapSchemes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quests",
                table: "Quests",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Quests",
                columns: new[] { "Id", "ConsDraw", "ConsLoose", "ConsWin", "Description", "Level", "Name" },
                values: new object[] { 1, "Ничего не нашлось", "Ничего не нашлось, получите 1 усталость", "Получите артефакт Х", "Найден старый склеп. Получите >2 успехов выносливости чтоб порыться в нем.", 0, "Low quest" });

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPoint_Quests_QuestId",
                table: "InterestPoint",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestPoint_Quests_QuestId",
                table: "InterestPoint");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quests",
                table: "Quests");

            migrationBuilder.DeleteData(
                table: "Quests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "QuestLevel",
                table: "MapSchemes");

            migrationBuilder.RenameTable(
                name: "Quests",
                newName: "Quest");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quest",
                table: "Quest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestPoint_Quest_QuestId",
                table: "InterestPoint",
                column: "QuestId",
                principalTable: "Quest",
                principalColumn: "Id");
        }
    }
}
