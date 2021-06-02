
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IAboutSettingservice
    {     
        Task<AboutSettings> GetAboutSettings();
        Task<AboutSettings> CreateAboutSettings(AboutSettings newAboutSettings);
        Task UpdateAboutSettings(AboutSettings AboutSettingsToBeUpdated, AboutSettings AboutSettings);

        Task<AboutSettingsCertificate> GetCertificateById(int id);
        Task<AboutSettingsCertificate> CreateCertificate(AboutSettingsCertificate newCertificate);
        Task UpdateCertificate(AboutSettingsCertificate CertificateToBeUpdated, AboutSettingsCertificate Certificate);
        Task DeleteCertificate(AboutSettingsCertificate Certificate);

        Task<AboutSettingsItem> GetItemteById(int id);
        Task<AboutSettingsItem> CreateItem(AboutSettingsItem newItem);
        Task UpdateItem(AboutSettingsItem ItemToBeUpdated, AboutSettingsItem Item);
        Task DeleteItem(AboutSettingsItem Item);
    }
}