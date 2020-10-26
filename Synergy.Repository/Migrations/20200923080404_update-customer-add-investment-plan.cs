using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Synergy.Repository.Migrations
{
    public partial class updatecustomeraddinvestmentplan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "ResponseLog",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 230, DateTimeKind.Utc).AddTicks(5152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 5, 9, 44, 10, 77, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "RequestLog",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 223, DateTimeKind.Utc).AddTicks(7206),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 5, 9, 44, 10, 71, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerAccount",
                nullable: false,
                defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 364, DateTimeKind.Utc).AddTicks(1173),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 8, 5, 9, 44, 10, 207, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "CustomerAccount",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "CustomerAccount",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "CustomerAccount",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InvestmnetCategory",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 431, DateTimeKind.Utc).AddTicks(1258)),
                    CategoryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmnetCategory", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "SynergyInvestment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 435, DateTimeKind.Utc).AddTicks(5381)),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    AvailableSlot = table.Column<int>(nullable: false),
                    SolOutSlot = table.Column<int>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SynergyInvestment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SynergyInvestment_InvestmnetCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "InvestmnetCategory",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SynergyInvestment_CategoryId",
                table: "SynergyInvestment",
                column: "CategoryId");

            migrationBuilder.InsertData(
                table: "InvestmnetCategory",
                columns: new[] { "CategoryName", "CreatedBy" },
                values: new object[,]
                {
                    {"Manufacturer","Admin"},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SynergyInvestment");

            migrationBuilder.DropTable(
                name: "InvestmnetCategory");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "CustomerAccount");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "CustomerAccount");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "ResponseLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 5, 9, 44, 10, 77, DateTimeKind.Utc).AddTicks(9027),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 230, DateTimeKind.Utc).AddTicks(5152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateLogged",
                table: "RequestLog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 5, 9, 44, 10, 71, DateTimeKind.Utc).AddTicks(2991),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 223, DateTimeKind.Utc).AddTicks(7206));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "CustomerAccount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 8, 5, 9, 44, 10, 207, DateTimeKind.Utc).AddTicks(3813),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 9, 23, 8, 4, 3, 364, DateTimeKind.Utc).AddTicks(1173));
        }
    }
}
