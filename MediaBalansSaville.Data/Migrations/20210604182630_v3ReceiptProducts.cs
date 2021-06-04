using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v3ReceiptProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ReceiptProduct_ReceiptProductId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Seos_ProductSeoId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Seos_ReceiptSeoId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "ReceiptProduct");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_ReceiptSeoId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSeoId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReceiptProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReceiptSeoId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ProductSeoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReceiptProductId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProductValues",
                table: "Receipts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 21, 26, 28, 603, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 21, 26, 28, 612, DateTimeKind.Local).AddTicks(1040));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 21, 26, 28, 612, DateTimeKind.Local).AddTicks(1070));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 21, 26, 28, 619, DateTimeKind.Local).AddTicks(3890));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 21, 26, 28, 619, DateTimeKind.Local).AddTicks(4530));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "ef4dee500091b1b14828e804f11e51d036555de7594581fcefa775dda5ea2b881ed9206c0d0adfaffc76b66b4f79e2e13c57c5d7ca6c114ff7fd1f60d49919ff", new DateTime(2021, 6, 4, 21, 26, 28, 614, DateTimeKind.Local).AddTicks(3340), "80857056821c4ba1858a33224d31cc916/4/202192628PM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductValues",
                table: "Receipts");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptSeoId",
                table: "Receipts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductSeoId",
                table: "Products",
                type: "int",
                nullable: true);

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
                name: "IX_Receipts_ReceiptSeoId",
                table: "Receipts",
                column: "ReceiptSeoId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSeoId",
                table: "Products",
                column: "ProductSeoId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Seos_ProductSeoId",
                table: "Products",
                column: "ProductSeoId",
                principalTable: "Seos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Seos_ReceiptSeoId",
                table: "Receipts",
                column: "ReceiptSeoId",
                principalTable: "Seos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
