using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v5SeoFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 23, 2, 44, 775, DateTimeKind.Local).AddTicks(2740));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 23, 2, 44, 784, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 23, 2, 44, 784, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 23, 2, 44, 796, DateTimeKind.Local).AddTicks(4070));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 4, 23, 2, 44, 796, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "ffccc997422fa1581a5ad7bd9716a33238dcc685400c9f6f150c2d47ce02ea6bc865efdd2758483701c170af95ca620f040cff70a73f59a658ef486698a386d1", new DateTime(2021, 6, 4, 23, 2, 44, 788, DateTimeKind.Local).AddTicks(1790), "b620ee62da4547c99856fde50b8dc2d26/4/2021110244PM" });

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ReceiptSeoId",
                table: "Receipts",
                column: "ReceiptSeoId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSeoId",
                table: "Products",
                column: "ProductSeoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Seos_ProductSeoId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Seos_ReceiptSeoId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_ReceiptSeoId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductSeoId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReceiptSeoId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ProductSeoId",
                table: "Products");

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
    }
}
