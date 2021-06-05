using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaBalansSaville.Data.Migrations
{
    public partial class v1Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsReceipt = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExportationCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportationCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exportations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exportations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Langs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Langs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Letters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PomegranateSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomegranateSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<int>(type: "int", nullable: false),
                    Page = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBlog = table.Column<bool>(type: "bit", nullable: false),
                    IsReceipt = table.Column<bool>(type: "bit", nullable: false),
                    IsProduct = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VideoCoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdVideoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoogleAnalyticsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookPixel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sliders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sliders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutSettingsCertificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AboutSettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSettingsCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutSettingsCertificates_AboutSettings_AboutSettingsId",
                        column: x => x.AboutSettingsId,
                        principalTable: "AboutSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutSettingsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AboutSettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSettingsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutSettingsItems_AboutSettings_AboutSettingsId",
                        column: x => x.AboutSettingsId,
                        principalTable: "AboutSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutSettingsLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OurStory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OurVision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WhySaville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutSettingsId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSettingsLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutSettingsLangs_AboutSettings_AboutSettingsId",
                        column: x => x.AboutSettingsId,
                        principalTable: "AboutSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutSettingsLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryLangs_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExportationLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExportationId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportationLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportationLangs_Exportations_ExportationId",
                        column: x => x.ExportationId,
                        principalTable: "Exportations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExportationLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FAQLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FAQId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQLangs_FAQs_FAQId",
                        column: x => x.FAQId,
                        principalTable: "FAQs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FAQLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PomegranateSettingsLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RhythmTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RhythmDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoostTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoostDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthInsuranceTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthInsuranceDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PomegranateSettingsId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PomegranateSettingsLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PomegranateSettingsLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PomegranateSettingsLangs_PomegranateSettings_PomegranateSettingsId",
                        column: x => x.PomegranateSettingsId,
                        principalTable: "PomegranateSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<int>(type: "int", nullable: false),
                    ProductSeoId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Seos_ProductSeoId",
                        column: x => x.ProductSeoId,
                        principalTable: "Seos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniqueId = table.Column<int>(type: "int", nullable: false),
                    IsBlog = table.Column<bool>(type: "bit", nullable: false),
                    ProductValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptSeoId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SlugUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipts_Seos_ReceiptSeoId",
                        column: x => x.ReceiptSeoId,
                        principalTable: "Seos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeoLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keys = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeoLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeoLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeoLangs_Seos_SeoId",
                        column: x => x.SeoId,
                        principalTable: "Seos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteSettingsLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdDetail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteSettingsId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteSettingsLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiteSettingsLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteSettingsLangs_SiteSettings_SiteSettingsId",
                        column: x => x.SiteSettingsId,
                        principalTable: "SiteSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AboutSettingsItemLang",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutSettingsItemId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutSettingsItemLang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutSettingsItemLang_AboutSettingsItems_AboutSettingsItemId",
                        column: x => x.AboutSettingsItemId,
                        principalTable: "AboutSettingsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AboutSettingsItemLang_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductLangs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCover = table.Column<bool>(type: "bit", nullable: false),
                    IsNutrition = table.Column<bool>(type: "bit", nullable: false),
                    RecordedAtDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "ReceiptLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preparation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptLangs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptLangs_Langs_LangId",
                        column: x => x.LangId,
                        principalTable: "Langs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptLangs_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptPhotos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    IsCover = table.Column<bool>(type: "bit", nullable: false),
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiptPhotos_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ExportationCountries",
                columns: new[] { "Id", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "", false, "Afghanistan" },
                    { 12, "", false, "Azerbaijan" },
                    { 11, "", false, "Austria" },
                    { 10, "", false, "Australia" },
                    { 8, "", false, "Armenia" },
                    { 7, "", false, "Argentina" },
                    { 9, "", false, "Aruba" },
                    { 5, "", false, "Angola" },
                    { 4, "", false, "Andorra" },
                    { 3, "", false, "Algeria" },
                    { 2, "", false, "Albania" },
                    { 6, "", false, "Antigua and Barbuda" }
                });

            migrationBuilder.InsertData(
                table: "Langs",
                columns: new[] { "Id", "Code", "IsActive", "IsDeleted", "Name", "RecordedAtDate", "SlugUrl", "UrlId" },
                values: new object[,]
                {
                    { 1, "az", true, false, "Azərbaycan", new DateTime(2021, 6, 5, 17, 19, 57, 743, DateTimeKind.Local).AddTicks(310), "az", 1 },
                    { 2, "ru", true, false, "Rusiya", new DateTime(2021, 6, 5, 17, 19, 57, 750, DateTimeKind.Local).AddTicks(9650), "ru", 2 },
                    { 3, "en", true, false, "İngiltərə", new DateTime(2021, 6, 5, 17, 19, 57, 750, DateTimeKind.Local).AddTicks(9690), "en", 3 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsActive", "IsDeleted", "Name", "RecordedAtDate", "SlugUrl", "UrlId" },
                values: new object[,]
                {
                    { 2, true, false, "user", new DateTime(2021, 6, 5, 17, 19, 57, 758, DateTimeKind.Local).AddTicks(4000), "user", 2 },
                    { 1, true, false, "admin", new DateTime(2021, 6, 5, 17, 19, 57, 758, DateTimeKind.Local).AddTicks(3360), "admin", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "RecordedAtDate", "SecretKey", "SlugUrl", "UrlId" },
                values: new object[] { 1, "admin@admin.com", "Admin", true, false, "Admin", "f44ce413194ed032b1c1f3595a13eefd2428300e2e9842d9d360c2c62a53edae381ed1b54986c4248b515ac750085553650131d09f639cc6d2fb60d2b1b01cee", "0534 895 22 84", new DateTime(2021, 6, 5, 17, 19, 57, 753, DateTimeKind.Local).AddTicks(2070), "a0335949143f4a49bf99ba46a5bb83c56/5/202151957PM", null, 0 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsCertificates_AboutSettingsId",
                table: "AboutSettingsCertificates",
                column: "AboutSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItemLang_AboutSettingsItemId",
                table: "AboutSettingsItemLang",
                column: "AboutSettingsItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItemLang_LangId",
                table: "AboutSettingsItemLang",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsItems_AboutSettingsId",
                table: "AboutSettingsItems",
                column: "AboutSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsLangs_AboutSettingsId",
                table: "AboutSettingsLangs",
                column: "AboutSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutSettingsLangs_LangId",
                table: "AboutSettingsLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLangs_CategoryId",
                table: "CategoryLangs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLangs_LangId",
                table: "CategoryLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportationLangs_ExportationId",
                table: "ExportationLangs",
                column: "ExportationId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportationLangs_LangId",
                table: "ExportationLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQLangs_FAQId",
                table: "FAQLangs",
                column: "FAQId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQLangs_LangId",
                table: "FAQLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_PomegranateSettingsLangs_LangId",
                table: "PomegranateSettingsLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_PomegranateSettingsLangs_PomegranateSettingsId",
                table: "PomegranateSettingsLangs",
                column: "PomegranateSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLangs_LangId",
                table: "ProductLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLangs_ProductId",
                table: "ProductLangs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPhotos_ProductId",
                table: "ProductPhotos",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductSeoId",
                table: "Products",
                column: "ProductSeoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptLangs_LangId",
                table: "ReceiptLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptLangs_ReceiptId",
                table: "ReceiptLangs",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptPhotos_ReceiptId",
                table: "ReceiptPhotos",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CategoryId",
                table: "Receipts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_ReceiptSeoId",
                table: "Receipts",
                column: "ReceiptSeoId");

            migrationBuilder.CreateIndex(
                name: "IX_SeoLangs_LangId",
                table: "SeoLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_SeoLangs_SeoId",
                table: "SeoLangs",
                column: "SeoId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettingsLangs_LangId",
                table: "SiteSettingsLangs",
                column: "LangId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteSettingsLangs_SiteSettingsId",
                table: "SiteSettingsLangs",
                column: "SiteSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutSettingsCertificates");

            migrationBuilder.DropTable(
                name: "AboutSettingsItemLang");

            migrationBuilder.DropTable(
                name: "AboutSettingsLangs");

            migrationBuilder.DropTable(
                name: "CategoryLangs");

            migrationBuilder.DropTable(
                name: "ExportationCountries");

            migrationBuilder.DropTable(
                name: "ExportationLangs");

            migrationBuilder.DropTable(
                name: "FAQLangs");

            migrationBuilder.DropTable(
                name: "Letters");

            migrationBuilder.DropTable(
                name: "PomegranateSettingsLangs");

            migrationBuilder.DropTable(
                name: "ProductLangs");

            migrationBuilder.DropTable(
                name: "ProductPhotos");

            migrationBuilder.DropTable(
                name: "ReceiptLangs");

            migrationBuilder.DropTable(
                name: "ReceiptPhotos");

            migrationBuilder.DropTable(
                name: "SeoLangs");

            migrationBuilder.DropTable(
                name: "SiteSettingsLangs");

            migrationBuilder.DropTable(
                name: "Sliders");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "AboutSettingsItems");

            migrationBuilder.DropTable(
                name: "Exportations");

            migrationBuilder.DropTable(
                name: "FAQs");

            migrationBuilder.DropTable(
                name: "PomegranateSettings");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "Langs");

            migrationBuilder.DropTable(
                name: "SiteSettings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AboutSettings");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Seos");
        }
    }
}
