using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v4AboutSettingsItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItemLang_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItemLang");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItemLang_AboutSettingsItems_AboutSettingsItemId",
                table: "AboutSettingsItemLang");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems");

            migrationBuilder.DropIndex(
                name: "IX_AboutSettingsItemLang_AboutSettingsId",
                table: "AboutSettingsItemLang");

            migrationBuilder.DropColumn(
                name: "AboutSettingsId",
                table: "AboutSettingsItemLang");

            migrationBuilder.AlterColumn<int>(
                name: "AboutSettingsId",
                table: "AboutSettingsItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AboutSettingsItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "AboutSettingsItemId",
                table: "AboutSettingsItemLang",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItemLang_AboutSettingsItems_AboutSettingsItemId",
                table: "AboutSettingsItemLang",
                column: "AboutSettingsItemId",
                principalTable: "AboutSettingsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems",
                column: "AboutSettingsId",
                principalTable: "AboutSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItemLang_AboutSettingsItems_AboutSettingsItemId",
                table: "AboutSettingsItemLang");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AboutSettingsItems");

            migrationBuilder.AlterColumn<int>(
                name: "AboutSettingsId",
                table: "AboutSettingsItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AboutSettingsItemId",
                table: "AboutSettingsItemLang",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AboutSettingsId",
                table: "AboutSettingsItemLang",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItemLang_AboutSettingsId",
                table: "AboutSettingsItemLang",
                column: "AboutSettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItemLang_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItemLang",
                column: "AboutSettingsId",
                principalTable: "AboutSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItemLang_AboutSettingsItems_AboutSettingsItemId",
                table: "AboutSettingsItemLang",
                column: "AboutSettingsItemId",
                principalTable: "AboutSettingsItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems",
                column: "AboutSettingsId",
                principalTable: "AboutSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
