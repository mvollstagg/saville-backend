using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Data.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Creation of Langs
            Lang azLang = new Lang
            {
                Id = 1,
                Name = "Azərbaycan",
                Code = "az",
                SlugUrl = "az",
                UrlId = 1,
                IsActive = true
            };

            Lang ruLang = new Lang
            {
                Id = 2,
                Name = "Rusiya",
                Code = "ru",
                SlugUrl = "ru",
                UrlId = 2,
                IsActive = true
            };

            Lang enLang = new Lang
            {
                Id = 3,
                Name = "İngiltərə",
                Code = "en",
                SlugUrl = "en",
                UrlId = 3,
                IsActive = true
            };

            modelBuilder.Entity<Lang>().HasData(azLang, ruLang, enLang);
            #endregion


            
            #region Cretion of User
            var admin = new User()
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@admin.com",
                PhoneNumber = "0534 895 22 84",
                IsActive = true
            };
            admin.PasswordHash = HashHelper.CreatePasswordHash("Admin123", admin.SecretKey);
            modelBuilder.Entity<User>().HasData(admin);
            #endregion

            #region Creation of Admin & User roles
            Role adminRole = new Role
            {
                Id = 1,
                Name = "admin",
                SlugUrl = "admin",
                UrlId = 1,
                IsActive = true
            };

            Role userRole = new Role
            {
                Id = 2,
                Name = "user",
                SlugUrl = "user",
                UrlId = 2,
                IsActive = true
            };

            modelBuilder.Entity<Role>().HasData(adminRole, userRole);
            #endregion

            #region UserRole Ataması
            UserRole adminUserRole = new UserRole
            {
                Id = 1,
                UserId = admin.Id,
                RoleId = adminRole.Id
            };

            modelBuilder.Entity<UserRole>().HasData(adminUserRole);
            #endregion
        }
    }
}
