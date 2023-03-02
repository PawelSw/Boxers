using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boxers.Migrations
{
    /// <inheritdoc />
    public partial class FullNameonTrainer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Trainers",
                newName: "FullName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Trainers",
                newName: "Name");
        }
    }
}
