using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v2CAT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsBlog",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 20, 0, 28, 89, DateTimeKind.Local).AddTicks(3860));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 20, 0, 28, 98, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 20, 0, 28, 98, DateTimeKind.Local).AddTicks(4310));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 20, 0, 28, 105, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 20, 0, 28, 106, DateTimeKind.Local).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "5324e9a652c5e238c56e6420e69ac86aae5e97055a1895622d7d61e254407d81849bb2c16ef7ffa48600ef95b9faee07a6e21c3744261fc5643e6089150c13f3", new DateTime(2021, 5, 30, 20, 0, 28, 100, DateTimeKind.Local).AddTicks(9550), "b5fefe3b6af7446086bde1b9b8152bfd5/30/202180028PM" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsBlog",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 19, 0, 32, 730, DateTimeKind.Local).AddTicks(3190));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 19, 0, 32, 739, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "Langs",
                keyColumn: "Id",
                keyValue: 3,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 19, 0, 32, 739, DateTimeKind.Local).AddTicks(1950));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 19, 0, 32, 746, DateTimeKind.Local).AddTicks(1580));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAtDate",
                value: new DateTime(2021, 5, 30, 19, 0, 32, 746, DateTimeKind.Local).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "RecordedAtDate", "SecretKey" },
                values: new object[] { "a7e3bf91fbcc0ae37b41c16d49a1751ff9649fd05128a68e2207c49f15f7bafb04565cb344c144f296f1858818fc9a29818ac5fb33a119a308783e9653787128", new DateTime(2021, 5, 30, 19, 0, 32, 741, DateTimeKind.Local).AddTicks(4180), "247912a4a8cc464ba68871b210a37ad05/30/202170032PM" });
        }
    }
}
