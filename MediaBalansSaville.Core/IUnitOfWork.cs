using System;
using System.Threading.Tasks;
using MediaBalansSaville.Core.Repositories;
namespace MediaBalansSaville.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAboutSettingsRepository AboutSettings { get; }
        IAboutSettingsCertificateRepository AboutSettingsCertificates { get; }
        IAboutSettingsItemRepository AboutSettingsItems { get; }
        ICategoryLangRepository CategoryLangs { get; }
        ICategoryRepository Categories { get; }
        IExportationRepository Exportations { get; }
        IExportationCountryRepository ExportationsCountries { get; }
        IFAQRepository FAQs { get; }
        ILangRepository Langs { get; }
        ILetterRepository Letters { get; }
        IPomegranateRepository PomegranateSettings { get; }
        IProductRepository Products { get; }
        IReceiptRepository Receipts { get; }
        IReceiptPhotoRepository ReceiptPhotos { get; }
        IRoleRepository Roles { get; }
        ISeoRepository Seos { get; }
        ISiteSettingsRepository SiteSettings { get; }
        ISliderRepository Sliders { get; }
        IUserRepository Users { get; }        
        IUserRoleRepository UserRoles { get; }
        Task<int> CommitAsync();
    }
}