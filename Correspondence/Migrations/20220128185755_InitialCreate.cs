using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Correspondence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_author", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "dtype",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dtype", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");
            
            migrationBuilder.InsertData(
                table: "dtype",
                columns: new[] { "name" },
                values: new object[] { "Фотография" });
            migrationBuilder.InsertData(
                table: "dtype",
                columns: new[] { "name" },
                values: new object[] { "Открытка" });
            migrationBuilder.InsertData(
                table: "dtype",
                columns: new[] { "name" },
                values: new object[] { "Письмо" });
            migrationBuilder.InsertData(
                table: "dtype",
                columns: new[] { "name" },
                values: new object[] { "Проповедь" });
            migrationBuilder.InsertData(
                table: "dtype",
                columns: new[] { "name" },
                values: new object[] { "Записки технические" });
            migrationBuilder.InsertData(
                table: "dtype",
                columns: new[] { "name" },
                values: new object[] { "Записки богословские" });
            migrationBuilder.InsertData(
                table: "dtype",
                columns: new[] { "name" },
                values: new object[] { "Записки бытовые, документы" });

            migrationBuilder.CreateTable(
                name: "event",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "files",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    format_date = table.Column<byte[]>(type: "longblob", nullable: true),
                    scan_date = table.Column<byte[]>(type: "longblob", nullable: true),
                    sverst_date = table.Column<byte[]>(type: "longblob", nullable: true),
                    format_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    scan_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sverst_name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    format_extension = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    scan_extension = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    sverst_extension = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    format_length = table.Column<int>(type: "int", nullable: true),
                    scan_length = table.Column<int>(type: "int", nullable: true),
                    sverst_length = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_files", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    full_place = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    street = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    house = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    owner = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "subevent",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subevent", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "subtheme",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subtheme", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "theme",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_theme", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateTable(
                name: "main",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    f_date = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    day = table.Column<int>(type: "int", nullable: true),
                    month = table.Column<int>(type: "int", nullable: true),
                    year = table.Column<int>(type: "int", nullable: true),
                    folder = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    no_public = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    id_author = table.Column<int>(type: "int", nullable: true),
                    id_event = table.Column<int>(type: "int", nullable: true),
                    id_subevent = table.Column<int>(type: "int", nullable: true),
                    id_theme = table.Column<int>(type: "int", nullable: true),
                    id_subtheme = table.Column<int>(type: "int", nullable: true),
                    id_place = table.Column<int>(type: "int", nullable: false),
                    id_dtype = table.Column<int>(type: "int", nullable: true),
                    comments = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    id_files = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_main", x => x.Id);
                    table.ForeignKey(
                        name: "main_ibfk_1",
                        column: x => x.id_author,
                        principalTable: "author",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "main_ibfk_2",
                        column: x => x.id_event,
                        principalTable: "event",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "main_ibfk_3",
                        column: x => x.id_subevent,
                        principalTable: "subevent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "main_ibfk_4",
                        column: x => x.id_subtheme,
                        principalTable: "subtheme",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "main_ibfk_5",
                        column: x => x.id_theme,
                        principalTable: "theme",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "main_ibfk_6",
                        column: x => x.id_place,
                        principalTable: "place",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "main_ibfk_7",
                        column: x => x.id_dtype,
                        principalTable: "dtype",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "main_ibfk_8",
                        column: x => x.id_files,
                        principalTable: "files",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_general_ci");

            migrationBuilder.CreateIndex(
                name: "i_author",
                table: "author",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "name",
                table: "dtype",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_event",
                table: "event",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "id_author",
                table: "main",
                column: "id_author");

            migrationBuilder.CreateIndex(
                name: "id_dtype",
                table: "main",
                column: "id_dtype");

            migrationBuilder.CreateIndex(
                name: "id_event",
                table: "main",
                column: "id_event");

            migrationBuilder.CreateIndex(
                name: "id_files",
                table: "main",
                column: "id_files");

            migrationBuilder.CreateIndex(
                name: "id_place",
                table: "main",
                column: "id_place");

            migrationBuilder.CreateIndex(
                name: "id_subevent",
                table: "main",
                column: "id_subevent");

            migrationBuilder.CreateIndex(
                name: "id_subtheme",
                table: "main",
                column: "id_subtheme");

            migrationBuilder.CreateIndex(
                name: "id_theme",
                table: "main",
                column: "id_theme");

            migrationBuilder.CreateIndex(
                name: "i_place",
                table: "place",
                column: "full_place",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_subevent",
                table: "subevent",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_subtheme",
                table: "subtheme",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "i_theme",
                table: "theme",
                column: "name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "main");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "event");

            migrationBuilder.DropTable(
                name: "subevent");

            migrationBuilder.DropTable(
                name: "subtheme");

            migrationBuilder.DropTable(
                name: "theme");

            migrationBuilder.DropTable(
                name: "place");

            migrationBuilder.DropTable(
                name: "dtype");

            migrationBuilder.DropTable(
                name: "files");
        }
    }
}
