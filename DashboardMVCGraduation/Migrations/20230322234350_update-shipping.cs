using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DashboardMVCGraduation.Migrations
{
    /// <inheritdoc />
    public partial class updateshipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_PaymentMethod",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MasterCards_MasterCardId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "MasterCards");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MasterCardId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Cart_PaymentMethodID",
                table: "Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCard",
                table: "CreditCard");

            migrationBuilder.DropColumn(
                name: "MasterCardId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ShipDate",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "CreditCard",
                newName: "CreditCards");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCard_CustomerId",
                table: "CreditCards",
                newName: "IX_CreditCards_CustomerId");

            migrationBuilder.AddColumn<float>(
                name: "Discount",
                table: "Cart",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MasterExpDate",
                table: "CreditCards",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CreditCards",
                type: "nchar(14)",
                fixedLength: true,
                maxLength: 14,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Area = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shippings_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_CartId",
                table: "Shippings",
                column: "CartId",
                unique: true,
                filter: "[CartId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CreditCards",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "CreditCards",
                newName: "CreditCard");

            migrationBuilder.RenameIndex(
                name: "IX_CreditCards_CustomerId",
                table: "CreditCard",
                newName: "IX_CreditCard_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "MasterCardId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ShipDate",
                table: "Cart",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MasterExpDate",
                table: "CreditCard",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CreditCard",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(14)",
                oldFixedLength: true,
                oldMaxLength: 14,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CreditCard",
                table: "CreditCard",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    MethodID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.MethodID);
                });

            migrationBuilder.CreateTable(
                name: "MasterCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterBalance = table.Column<int>(type: "int", nullable: true),
                    MasterExpDate = table.Column<DateTime>(type: "date", nullable: true),
                    MasterID = table.Column<string>(type: "nchar(14)", fixedLength: true, maxLength: 14, nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MasterCards_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "MethodID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MasterCardId",
                table: "Customers",
                column: "MasterCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_PaymentMethodID",
                table: "Cart",
                column: "PaymentMethodID");

            migrationBuilder.CreateIndex(
                name: "IX_MasterCards_PaymentMethodId",
                table: "MasterCards",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_PaymentMethod",
                table: "Cart",
                column: "PaymentMethodID",
                principalTable: "PaymentMethod",
                principalColumn: "MethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MasterCards_MasterCardId",
                table: "Customers",
                column: "MasterCardId",
                principalTable: "MasterCards",
                principalColumn: "Id");
        }
    }
}
