using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JsonWebTokenAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Isbikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    istasyon_no = table.Column<int>(type: "int", nullable: false),
                    adi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aktif = table.Column<bool>(type: "bit", nullable: false),
                    bos = table.Column<int>(type: "int", nullable: false),
                    dolu = table.Column<int>(type: "int", nullable: false),
                    lat = table.Column<float>(type: "real", nullable: false),
                    lon = table.Column<float>(type: "real", nullable: false),
                    sonBaglanti = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Isbikes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TokenCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Isbikes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
