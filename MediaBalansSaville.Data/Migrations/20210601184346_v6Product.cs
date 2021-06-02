using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v6Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NutritionFactsPhotoUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Volume",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ReceiptPhotos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCover = table.Column<bool>(type: "bit", nullable: false),
                    IsNutrition = table.Column<bool>(type: "bit", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPhotos_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptPhotos_Products_ProductId",
                table: "ReceiptPhotos",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptPhotos_Products_ProductId",
                table: "ReceiptPhotos");

            migrationBuilder.DropTable(
                name: "ProductPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptPhotos_ProductId",
                table: "ReceiptPhotos");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ReceiptPhotos");

            migrationBuilder.AddColumn<string>(
                name: "NutritionFactsPhotoUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Volume",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 22, 18, 14, 244, DateTimeKind.Local).AddTicks(7170));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 22, 18, 14, 252, DateTimeKind.Local).AddTicks(4130));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 22, 18, 14, 252, DateTimeKind.Local).AddTicks(4160));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 22, 18, 14, 259, DateTimeKind.Local).AddTicks(8080));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 22, 18, 14, 259, DateTimeKind.Local).AddTicks(8720));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "9b71a48c2682b5db3ebecb589e3a96511cca761ee0f6b1d9d9c9ef5940a9e2f281bc0bfad29ad3c189a04d4c07d8e0e76dd995830211ec3f5b42cc130d691db4", new DateTime(2021, 5, 31, 22, 18, 14, 254, DateTimeKind.Local).AddTicks(6910), "ec7b091df65f496b8d0491b3959afa415/31/2021101814PM" });
        }
    }
}
