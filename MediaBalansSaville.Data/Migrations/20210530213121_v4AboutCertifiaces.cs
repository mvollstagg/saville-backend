using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v4AboutCertifiaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AboutSettingsCertificates",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 0, 31, 20, 329, DateTimeKind.Local).AddTicks(9870));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 0, 31, 20, 337, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 0, 31, 20, 337, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 0, 31, 20, 344, DateTimeKind.Local).AddTicks(8910));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 31, 0, 31, 20, 344, DateTimeKind.Local).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "ddba7a229e569c4b28f7e0dc8565dccd74d6e1f7dc03d35bbda6b38b77105d336f7c6627a0c47c88683feaef4c2cc3da0a18023d0583114ae12f32784c32e1df", new DateTime(2021, 5, 31, 0, 31, 20, 340, DateTimeKind.Local).AddTicks(970), "cb780f2724e243da84fcb75dcf87af5d5/31/2021123120AM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AboutSettingsCertificates");

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 23, 52, 6, 63, DateTimeKind.Local).AddTicks(5970));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 23, 52, 6, 72, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 23, 52, 6, 72, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 23, 52, 6, 79, DateTimeKind.Local).AddTicks(8270));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 23, 52, 6, 79, DateTimeKind.Local).AddTicks(8930));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "43680ab8bd82d52ae7c1227b16099f329371e19aa590f175d2678e684b64ac5ea53ac98e591257aaaaab75ae916307d44075c166cdd3a6eb6430af8f63852383", new DateTime(2021, 5, 30, 23, 52, 6, 74, DateTimeKind.Local).AddTicks(8700), "ff676fc30d2c4933b2ae8e5904455ecf5/30/2021115206PM" });
        }
    }
}
