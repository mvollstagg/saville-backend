using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v2SiteSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderDetails",
                table: "SiteSettingsLangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SliderTitle",
                table: "SiteSettingsLangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 19, 4, 8, 865, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 19, 4, 8, 875, DateTimeKind.Local).AddTicks(6110));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 19, 4, 8, 875, DateTimeKind.Local).AddTicks(6150));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 19, 4, 8, 883, DateTimeKind.Local).AddTicks(9430));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 19, 4, 8, 884, DateTimeKind.Local).AddTicks(60));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "c6d3f51ff85fec296dbd14d70719d403e7c63a168536ce4c9cedd3f5f099a65fe7b4065ed293baffe4e453cd827b9130e5501e1462c04f253c577db2eeab571a", new DateTime(2021, 6, 5, 19, 4, 8, 877, DateTimeKind.Local).AddTicks(9900), "0b319023771744d2b17e0227b243900e6/5/202170408PM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderDetails",
                table: "SiteSettingsLangs");

            migrationBuilder.DropColumn(
                name: "SliderTitle",
                table: "SiteSettingsLangs");

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 17, 19, 57, 743, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 17, 19, 57, 750, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 17, 19, 57, 750, DateTimeKind.Local).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 17, 19, 57, 758, DateTimeKind.Local).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 6, 5, 17, 19, 57, 758, DateTimeKind.Local).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "f44ce413194ed032b1c1f3595a13eefd2428300e2e9842d9d360c2c62a53edae381ed1b54986c4248b515ac750085553650131d09f639cc6d2fb60d2b1b01cee", new DateTime(2021, 6, 5, 17, 19, 57, 753, DateTimeKind.Local).AddTicks(2070), "a0335949143f4a49bf99ba46a5bb83c56/5/202151957PM" });
        }
    }
}
