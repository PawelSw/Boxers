using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boxers.Migrations
{
    /// <inheritdoc />
    public partial class BoxerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_achievements_boxers_BoxerId",
                table: "achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_boxers_trainers_TrainerId",
                table: "boxers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_trainers",
                table: "trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_boxers",
                table: "boxers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_achievements",
                table: "achievements");

            migrationBuilder.RenameTable(
                name: "trainers",
                newName: "Trainers");

            migrationBuilder.RenameTable(
                name: "boxers",
                newName: "Boxers");

            migrationBuilder.RenameTable(
                name: "achievements",
                newName: "Achievements");

            migrationBuilder.RenameIndex(
                name: "IX_boxers_TrainerId",
                table: "Boxers",
                newName: "IX_Boxers_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_achievements_BoxerId",
                table: "Achievements",
                newName: "IX_Achievements_BoxerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Boxers",
                table: "Boxers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Boxers_BoxerId",
                table: "Achievements",
                column: "BoxerId",
                principalTable: "Boxers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boxers_Trainers_TrainerId",
                table: "Boxers",
                column: "TrainerId",
                principalTable: "Trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Boxers_BoxerId",
                table: "Achievements");

            migrationBuilder.DropForeignKey(
                name: "FK_Boxers_Trainers_TrainerId",
                table: "Boxers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainers",
                table: "Trainers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Boxers",
                table: "Boxers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Achievements",
                table: "Achievements");

            migrationBuilder.RenameTable(
                name: "Trainers",
                newName: "trainers");

            migrationBuilder.RenameTable(
                name: "Boxers",
                newName: "boxers");

            migrationBuilder.RenameTable(
                name: "Achievements",
                newName: "achievements");

            migrationBuilder.RenameIndex(
                name: "IX_Boxers_TrainerId",
                table: "boxers",
                newName: "IX_boxers_TrainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Achievements_BoxerId",
                table: "achievements",
                newName: "IX_achievements_BoxerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_trainers",
                table: "trainers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_boxers",
                table: "boxers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_achievements",
                table: "achievements",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_achievements_boxers_BoxerId",
                table: "achievements",
                column: "BoxerId",
                principalTable: "boxers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_boxers_trainers_TrainerId",
                table: "boxers",
                column: "TrainerId",
                principalTable: "trainers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
