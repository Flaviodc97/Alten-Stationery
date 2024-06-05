using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableRefills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RefillId",
                table: "Alerts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Refill",
                columns: table => new
                {
                    RefillId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefillDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refill", x => x.RefillId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_RefillId",
                table: "Alerts",
                column: "RefillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Refill_RefillId",
                table: "Alerts",
                column: "RefillId",
                principalTable: "Refill",
                principalColumn: "RefillId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Refill_RefillId",
                table: "Alerts");

            migrationBuilder.DropTable(
                name: "Refill");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_RefillId",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "RefillId",
                table: "Alerts");
        }
    }
}
