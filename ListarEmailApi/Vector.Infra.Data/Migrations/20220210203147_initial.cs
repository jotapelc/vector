using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vector.Infra.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "avatares_mock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    mail = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    savedIn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_avatares_mock", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "avatares_mock");
        }
    }
}
