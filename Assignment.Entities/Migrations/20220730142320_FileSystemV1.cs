using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Entities.Migrations
{
    public partial class FileSystemV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "fileUploadInfo",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    filepath = table.Column<string>(type: "text", nullable: true),
                    filename = table.Column<string>(type: "text", nullable: true),
                    filetype = table.Column<string>(type: "text", nullable: true),
                    makeby = table.Column<string>(type: "text", nullable: true),
                    makedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    updateby = table.Column<string>(type: "text", nullable: true),
                    updatedate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fileUploadInfo", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "fileUploadInfo",
                schema: "public");
        }
    }
}
