using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Synergy.Repository.Migrations
{
    public partial class requestLogResponseLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: false),
                    Payload = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    DateLogged = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 9, 20, 51, 50, 696, DateTimeKind.Utc).AddTicks(1038)),
                    RequestrefernceId = table.Column<string>(nullable: true),
                    UniqueReferenceId = table.Column<string>(nullable: false),
                    RequestMethod = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResponseLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueReferenceId = table.Column<string>(nullable: false),
                    Payload = table.Column<string>(nullable: false),
                    DateLogged = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 6, 9, 20, 51, 50, 704, DateTimeKind.Utc).AddTicks(3961)),
                    StatusCode = table.Column<int>(nullable: false),
                    SynergyStatusCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseLog", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestLog");

            migrationBuilder.DropTable(
                name: "ResponseLog");
        }
    }
}
