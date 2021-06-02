using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v3AboutSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems");

            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItems_Langs_LangId",
                table: "AboutSettingsItems");

            migrationBuilder.DropIndex(
                name: "IX_AboutSettingsItems_LangId",
                table: "AboutSettingsItems");

            migrationBuilder.DropColumn(
                name: "CopyrightText",
                table: "SiteSettingsLangs");

            migrationBuilder.DropColumn(
                name: "MetaTags",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "AboutSettingsItems");

            migrationBuilder.DropColumn(
                name: "LangId",
                table: "AboutSettingsItems");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AboutSettingsItems");

            migrationBuilder.AlterColumn<int>(
                name: "AboutSettingsId",
                table: "AboutSettingsItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AboutSettingsItemLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutSettingsId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    AboutSettingsItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSettingsItemLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutSettingsItemLang_AboutSettings_AboutSettingsId",
                        column: x => x.AboutSettingsId,
                        principalTable: "AboutSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutSettingsItemLang_AboutSettingsItems_AboutSettingsItemId",
                        column: x => x.AboutSettingsItemId,
                        principalTable: "AboutSettingsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AboutSettingsItemLang_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItemLang_AboutSettingsId",
                table: "AboutSettingsItemLang",
                column: "AboutSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItemLang_AboutSettingsItemId",
                table: "AboutSettingsItemLang",
                column: "AboutSettingsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItemLang_LangId",
                table: "AboutSettingsItemLang",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems",
                column: "AboutSettingsId",
                principalTable: "AboutSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems");

            migrationBuilder.DropTable(
                name: "AboutSettingsItemLang");

            migrationBuilder.AddColumn<string>(
                name: "CopyrightText",
                table: "SiteSettingsLangs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaTags",
                table: "SiteSettings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AboutSettingsId",
                table: "AboutSettingsItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "AboutSettingsItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LangId",
                table: "AboutSettingsItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AboutSettingsItems",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItems_LangId",
                table: "AboutSettingsItems",
                column: "LangId");

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                table: "AboutSettingsItems",
                column: "AboutSettingsId",
                principalTable: "AboutSettings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AboutSettingsItems_Langs_LangId",
                table: "AboutSettingsItems",
                column: "LangId",
                principalTable: "Langs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
