using Microsoft.EntityFrameworkCore.Migrations;

namespace Correspondence.Migrations
{
    public partial class Change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "main_ibfk_1",
                table: "main");

            migrationBuilder.DropForeignKey(
                name: "main_ibfk_8",
                table: "main");

            migrationBuilder.AddForeignKey(
                name: "main_ibfk_1",
                table: "main",
                column: "id_author",
                principalTable: "author",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "main_ibfk_8",
                table: "main",
                column: "id_files",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "main_ibfk_1",
                table: "main");

            migrationBuilder.DropForeignKey(
                name: "main_ibfk_8",
                table: "main");

            migrationBuilder.AddForeignKey(
                name: "main_ibfk_1",
                table: "main",
                column: "id_author",
                principalTable: "author",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "main_ibfk_8",
                table: "main",
                column: "id_files",
                principalTable: "files",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
