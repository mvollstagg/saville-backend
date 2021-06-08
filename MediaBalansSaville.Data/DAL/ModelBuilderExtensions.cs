using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.Entities;
using System.Collections.Generic;

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

            #region Creation of Countries
            var countries = new List<ExportationCountry>
            {
				new ExportationCountry { Id = 1, Name = "Afghanistan", Code = "AF" },
				new ExportationCountry { Id = 2, Name = "Albania", Code = "AL" },
				new ExportationCountry { Id = 3, Name = "Algeria", Code = "DZ" },
				new ExportationCountry { Id = 4, Name = "Andorra", Code = "AD" },
				new ExportationCountry { Id = 5, Name = "Angola", Code = "AO" },
				new ExportationCountry { Id = 6, Name = "Antigua and Barbuda", Code = "AG" },
				new ExportationCountry { Id = 7, Name = "Argentina", Code = "AR" },
				new ExportationCountry { Id = 9, Name = "Aruba", Code = "AW" },
				new ExportationCountry { Id = 10, Name = "Australia", Code = "AU" },
				new ExportationCountry { Id = 11, Name = "Austria", Code = "AT" },
				new ExportationCountry { Id = 12, Name = "Azerbaijan", Code = "AZ" },
                new ExportationCountry { Id = 13, Name = "Bahrain", Code = "BH" },
                new ExportationCountry { Id = 14, Name = "Bangladesh", Code = "BD" },
                new ExportationCountry { Id = 15, Name = "Belarus", Code = "BY" },
                new ExportationCountry { Id = 16, Name = "Belgium", Code = "BE" },
                new ExportationCountry { Id = 17, Name = "Bosnia and Herzegovina", Code = "BA" },
                new ExportationCountry { Id = 18, Name = "Brazil", Code = "BR" },
                new ExportationCountry { Id = 19, Name = "Bulgaria", Code = "BG" },
                new ExportationCountry { Id = 20, Name = "Canada", Code = "CA" },
                new ExportationCountry { Id = 21, Name = "Central African Republic", Code = "CF" },
                new ExportationCountry { Id = 22, Name = "China", Code = "CN" },
                new ExportationCountry { Id = 23, Name = "Colombia", Code = "CO" },
                new ExportationCountry { Id = 24, Name = "Cyprus", Code = "CY" },
                new ExportationCountry { Id = 25, Name = "Czechia", Code = "CZ" },
                new ExportationCountry { Id = 26, Name = "Denmark", Code = "DK" },
                new ExportationCountry { Id = 27, Name = "Egypt", Code = "EG" },
                new ExportationCountry { Id = 28, Name = "Estonia", Code = "EE" },
                new ExportationCountry { Id = 29, Name = "Ethiopia", Code = "ET" },
                new ExportationCountry { Id = 30, Name = "Finland", Code = "FI" },
				new ExportationCountry { Id = 31, Name = "France", Code = "FR" },
				new ExportationCountry { Id = 32, Name = "Georgia", Code = "GE" },
                new ExportationCountry { Id = 33, Name = "Germany", Code = "DE" },
                new ExportationCountry { Id = 34, Name = "Greece", Code = "GR" },
                new ExportationCountry { Id = 35, Name = "Hong Kong	", Code = "HK" },
                new ExportationCountry { Id = 36, Name = "Hungary", Code = "HU" },
                new ExportationCountry { Id = 37, Name = "Iceland", Code = "IS" },
                new ExportationCountry { Id = 38, Name = "India", Code = "IN" },
                new ExportationCountry { Id = 39, Name = "Indonesia", Code = "ID" },
                new ExportationCountry { Id = 40, Name = "Iran", Code = "IR" },
                new ExportationCountry { Id = 41, Name = "Iraq", Code = "IQ" },
                new ExportationCountry { Id = 42, Name = "Ireland", Code = "IE" },
                new ExportationCountry { Id = 43, Name = "Israel", Code = "IL" },
                new ExportationCountry { Id = 44, Name = "Italy", Code = "IT" },
                new ExportationCountry { Id = 45, Name = "Japan", Code = "JP" },
                new ExportationCountry { Id = 46, Name = "Jordan", Code = "JO" },
                new ExportationCountry { Id = 47, Name = "Kazakhstan", Code = "KZ" },
                new ExportationCountry { Id = 48, Name = "Kuwait", Code = "KW" },
                new ExportationCountry { Id = 49, Name = "Kyrgyzstan", Code = "KG" },
                new ExportationCountry { Id = 50, Name = "Latvia", Code = "LV" },
                new ExportationCountry { Id = 51, Name = "Lebanon", Code = "LB" },
				new ExportationCountry { Id = 52, Name = "Libya", Code = "LY" },
                new ExportationCountry { Id = 53, Name = "Lithuania", Code = "LT" },
                new ExportationCountry { Id = 54, Name = "Malta", Code = "MT" },
                new ExportationCountry { Id = 55, Name = "Mexico", Code = "MX" },
                new ExportationCountry { Id = 56, Name = "Moldova", Code = "MD" },
                new ExportationCountry { Id = 57, Name = "Netherlands", Code = "NL" },
                new ExportationCountry { Id = 58, Name = "New Zealand", Code = "NZ" },
                new ExportationCountry { Id = 59, Name = "Norway", Code = "NO" },
                new ExportationCountry { Id = 60, Name = "Oman", Code = "OM" },
                new ExportationCountry { Id = 61, Name = "Pakistan", Code = "PK" },
                new ExportationCountry { Id = 62, Name = "Portugal", Code = "PT" },
                new ExportationCountry { Id = 63, Name = "Qatar", Code = "QA" },
                new ExportationCountry { Id = 64, Name = "Romania", Code = "RO" },
                new ExportationCountry { Id = 65, Name = "Russian Federation", Code = "RU" },
                new ExportationCountry { Id = 66, Name = "Spain", Code = "E" },
                new ExportationCountry { Id = 67, Name = "Sweden", Code = "SE" },
                new ExportationCountry { Id = 68, Name = "Turkey", Code = "TR" },
                new ExportationCountry { Id = 69, Name = "Turkmenistan", Code = "TM" },
                new ExportationCountry { Id = 70, Name = "Ukraine", Code = "UA" },
                new ExportationCountry { Id = 81, Name = "United Arab Emirates", Code = "AE" },
				new ExportationCountry { Id = 82, Name = "United Kingdom", Code = "GB" },
                new ExportationCountry { Id = 83, Name = "United States of America", Code = "US" },
                new ExportationCountry { Id = 84, Name = "Uzbekistan", Code = "UZ" },
                new ExportationCountry { Id = 85, Name = "Venezuela", Code = "VE" },
                new ExportationCountry { Id = 86, Name = "Yemen", Code = "YE" }
            };

            modelBuilder.Entity<ExportationCountry>().HasData(countries);
            #endregion
            
        }
    }
}
