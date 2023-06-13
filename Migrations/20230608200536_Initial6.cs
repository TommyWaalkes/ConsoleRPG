using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RPGConsoleGame.Migrations
{
    /// <inheritdoc />
    public partial class Initial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attacks_Jobs_JobId",
                table: "Attacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Jobs_JobId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Attacks_JobId",
                table: "Attacks");

            migrationBuilder.DropColumn(
                name: "JobId",
                table: "Attacks");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Jobs_JobId",
                table: "Players",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Jobs_JobId",
                table: "Players");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Players",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "JobId",
                table: "Attacks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_JobId",
                table: "Attacks",
                column: "JobId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attacks_Jobs_JobId",
                table: "Attacks",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Jobs_JobId",
                table: "Players",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
