using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMVCGraduation.Migrations
{
    /// <inheritdoc />
    public partial class updatecreditcard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MasterCards",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MasterId",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "MasterCardId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterExpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CardTypeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    MasterBalance = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_CreditCard",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MasterCardId",
                table: "Customers",
                column: "MasterCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_CustomerId",
                table: "CreditCard",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MasterCards_MasterCardId",
                table: "Customers",
                column: "MasterCardId",
                principalTable: "MasterCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MasterCards_MasterCardId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MasterCardId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MasterCardId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MasterId",
                table: "Customers",
                column: "MasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MasterCards",
                table: "Customers",
                column: "MasterId",
                principalTable: "MasterCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
