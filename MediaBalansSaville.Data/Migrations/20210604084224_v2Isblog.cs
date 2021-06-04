using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v2Isblog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlog",
                table: "Receipts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReceiptProduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptProduct_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 11, 42, 23, 560, DateTimeKind.Local).AddTicks(3370));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 11, 42, 23, 568, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 11, 42, 23, 568, DateTimeKind.Local).AddTicks(3940));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 11, 42, 23, 575, DateTimeKind.Local).AddTicks(5500));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 11, 42, 23, 575, DateTimeKind.Local).AddTicks(6140));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "039c2d87f5e50b52fa10e9bb758b156a0c78b15ab8de5fa8f1da9048007ec66055386bf623acdba4708653ee28e26f8c57b42e94f777556c53e5c3ebce7c0b7c", new DateTime(2021, 6, 4, 11, 42, 23, 570, DateTimeKind.Local).AddTicks(8180), "470c59c6c7554b69b5bc3d816c99da286/4/2021114223AM" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReceiptProductId",
                table: "Products",
                column: "ReceiptProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptProduct_ReceiptId",
                table: "ReceiptProduct",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ReceiptProduct_ReceiptProductId",
                table: "Products",
                column: "ReceiptProductId",
                principalTable: "ReceiptProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ReceiptProduct_ReceiptProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ReceiptProduct");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReceiptProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsBlog",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ReceiptProductId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 0, 27, 17, 707, DateTimeKind.Local).AddTicks(30));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 0, 27, 17, 730, DateTimeKind.Local).AddTicks(9190));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 0, 27, 17, 730, DateTimeKind.Local).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 0, 27, 17, 746, DateTimeKind.Local).AddTicks(5920));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 0, 27, 17, 746, DateTimeKind.Local).AddTicks(6570));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "63a2fc904cc17426f994b55213d1726f2c5866b8bcd961b60ddf84aefea10aeb53727599338a4f1780a39d8396c2f877d90f28a397f793a7de319cfa6941c75d", new DateTime(2021, 6, 4, 0, 27, 17, 740, DateTimeKind.Local).AddTicks(910), "25f18e7132ef4b2580714b24413941c56/4/2021122717AM" });
        }
    }
}
