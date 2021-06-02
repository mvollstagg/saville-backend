using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v7Prod2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptPhotos_Products_ProductId",
                table: "ReceiptPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptPhotos_ProductId",
                table: "ReceiptPhotos");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ReceiptPhotos");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "ProductLangs");

            migrationBuilder.AddColumn<DateTime>(
                name: "RecordedAtDate",
                table: "ProductPhotos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 2, 0, 31, 43, 375, DateTimeKind.Local).AddTicks(7590));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 2, 0, 31, 43, 388, DateTimeKind.Local).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 2, 0, 31, 43, 388, DateTimeKind.Local).AddTicks(3270));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 2, 0, 31, 43, 396, DateTimeKind.Local).AddTicks(920));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 2, 0, 31, 43, 396, DateTimeKind.Local).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "f41765ee449bb57f831e00678392fb5fbe0706c0c893e79f2c46e2599c8fc00b87d2e461eab7485a4bd54472b4fb5cb396d73314dd226c00f215db6796ffef0c", new DateTime(2021, 6, 2, 0, 31, 43, 390, DateTimeKind.Local).AddTicks(9750), "4cf9ce1829204ee2880bac103bf401b26/2/2021123143AM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordedAtDate",
                table: "ProductPhotos");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ReceiptPhotos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "ProductLangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 1, 21, 43, 45, 80, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 1, 21, 43, 45, 89, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 1, 21, 43, 45, 89, DateTimeKind.Local).AddTicks(5080));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 1, 21, 43, 45, 99, DateTimeKind.Local).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 1, 21, 43, 45, 99, DateTimeKind.Local).AddTicks(7920));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "8cd28634aef38f0f21a339576df647e7abc9dc3224890437b99a443e0820e23aa2ffd38a2a4bc8ef30719555487a32bda364b2e0a2568117efd54f78d2242ca8", new DateTime(2021, 6, 1, 21, 43, 45, 94, DateTimeKind.Local).AddTicks(2130), "f639b0b2968545a39efcd3b39b83f1466/1/202194345PM" });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptPhotos_ProductId",
                table: "ReceiptPhotos",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptPhotos_Products_ProductId",
                table: "ReceiptPhotos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
