
using MediaBalansSaville.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MediaBalansSaville.Data.DAL
{
    public class ApplicationDbContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string ConnetDeveloper="Server=saville.mssql.somee.com;Database=saville;User Id=saville_SQLLogin_1;Password=n3cd3ytml6;MultipleActiveResultSets=true";
            optionsBuilder.UseLazyLoadingProxies()
            .UseSqlServer(ConnetDeveloper)
            .EnableSensitiveDataLogging()
            .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.DetachedLazyLoadingWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<AboutSettings> AboutSettings { get; set; }
        public DbSet<AboutSettingsCertificate> AboutSettingsCertificates { get; set; }
        public DbSet<AboutSettingsLang> AboutSettingsLangs { get; set; }
        public DbSet<AboutSettingsItem> AboutSettingsItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryLang> CategoryLangs { get; set; }
        public DbSet<Exportation> Exportations { get; set; }
        public DbSet<ExportationCountry> ExportationCountries { get; set; }
        public DbSet<ExportationLang> ExportationLangs { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<FAQLang> FAQLangs { get; set; }
        public DbSet<Lang> Langs { get; set; }
        public DbSet<Letter> Letters { get; set; }
        public DbSet<PomegranateSettings> PomegranateSettings { get; set; }
        public DbSet<PomegranateSettingsLang> PomegranateSettingsLangs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<ProductLang> ProductLangs { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptLang> ReceiptLangs { get; set; }
        public DbSet<ReceiptPhoto> ReceiptPhotos { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Seo> Seos { get; set; }
        public DbSet<SeoLang> SeoLangs { get; set; }
        public DbSet<SiteSettings> SiteSettings { get; set; }
        public DbSet<SiteSettingsLang> SiteSettingsLangs { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderLang> SliderLangs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        
    }
}