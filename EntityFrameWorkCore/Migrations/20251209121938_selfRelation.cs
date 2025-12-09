using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntityFrameWorkCore.Migrations
{
    /// <inheritdoc />
    public partial class selfRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "St_super",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_St_super",
                table: "Students",
                column: "St_super");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Students_St_super",
                table: "Students",
                column: "St_super",
                principalTable: "Students",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Students_St_super",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_St_super",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "St_super",
                table: "Students");
        }
    }
}
