using Microsoft.EntityFrameworkCore.Migrations;

namespace Correspondence.Migrations
{
    public partial class RenameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sverst_date",
                table: "files",
                newName: "sverst_data");

            migrationBuilder.RenameColumn(
                name: "scan_date",
                table: "files",
                newName: "scan_data");

            migrationBuilder.RenameColumn(
                name: "format_date",
                table: "files",
                newName: "format_data");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sverst_data",
                table: "files",
                newName: "sverst_date");

            migrationBuilder.RenameColumn(
                name: "scan_data",
                table: "files",
                newName: "scan_date");

            migrationBuilder.RenameColumn(
                name: "format_data",
                table: "files",
                newName: "format_date");
        }
    }
}
