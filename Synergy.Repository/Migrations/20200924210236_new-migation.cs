using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Synergy.Repository.Migrations
{
    public partial class newmigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SynergyInvestment",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 674, DateTimeKind.Utc).AddTicks(6333),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 435, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "ResponseLog",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 478, DateTimeKind.Utc).AddTicks(7841),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 230, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "RequestLog",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 469, DateTimeKind.Utc).AddTicks(6963),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 223, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "InvestmnetCategory",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 669, DateTimeKind.Utc).AddTicks(1010),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 431, DateTimeKind.Utc).AddTicks(1258));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerAccount",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 655, DateTimeKind.Utc).AddTicks(1985),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 364, DateTimeKind.Utc).AddTicks(1173));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "CustomerAccount",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AdminUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    PasswordKey = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminUser", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminUser");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "CustomerAccount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "SynergyInvestment",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 435, DateTimeKind.Utc).AddTicks(5381),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 674, DateTimeKind.Utc).AddTicks(6333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "ResponseLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 230, DateTimeKind.Utc).AddTicks(5152),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 478, DateTimeKind.Utc).AddTicks(7841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "RequestLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 223, DateTimeKind.Utc).AddTicks(7206),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 469, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "InvestmnetCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 431, DateTimeKind.Utc).AddTicks(1258),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 669, DateTimeKind.Utc).AddTicks(1010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerAccount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 364, DateTimeKind.Utc).AddTicks(1173),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 24, 21, 2, 35, 655, DateTimeKind.Utc).AddTicks(1985));
        }
    }
}
