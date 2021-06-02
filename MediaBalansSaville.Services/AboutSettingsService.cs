using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class AboutSettingservice : IAboutSettingservice
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public AboutSettingservice(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<AboutSettings> CreateAboutSettings(AboutSettings newAboutSettings)
        {
            await _unitOfWork.AboutSettings.AddAsync(newAboutSettings);
            await _unitOfWork.CommitAsync();
            return newAboutSettings;
        }

        public async Task<AboutSettingsCertificate> CreateCertificate(AboutSettingsCertificate newCertificate)
        {
            await _unitOfWork.AboutSettingsCertificates.AddAsync(newCertificate);
            await _unitOfWork.CommitAsync();
            return newCertificate;
        }

        public async Task<AboutSettingsItem> CreateItem(AboutSettingsItem newItem)
        {
            await _unitOfWork.AboutSettingsItems.AddAsync(newItem);
            await _unitOfWork.CommitAsync();
            return newItem;
        }

        public async Task DeleteCertificate(AboutSettingsCertificate Certificate)
        {
            _unitOfWork.AboutSettingsCertificates.Remove(Certificate);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteItem(AboutSettingsItem Item)
        {
            _unitOfWork.AboutSettingsItems.Remove(Item);
            await _unitOfWork.CommitAsync();
        }

        public async Task<AboutSettings> GetAboutSettings()
        {
            return await _unitOfWork.AboutSettings.GetAboutSettings();
        }

        public async Task<AboutSettingsCertificate> GetCertificateById(int id)
        {
            return await _unitOfWork.AboutSettingsCertificates.GetByIdAsync(id);
        }

        public async Task<AboutSettingsItem> GetItemteById(int id)
        {
            return await _unitOfWork.AboutSettingsItems.GetItemById(id);
        }

        public async Task UpdateAboutSettings(AboutSettings AboutSettingsToBeUpdated, AboutSettings AboutSettings)
        {
            AboutSettingsToBeUpdated = AboutSettings;
            AboutSettingsToBeUpdated.AboutSettingsCertificates = AboutSettings.AboutSettingsCertificates;
            AboutSettingsToBeUpdated.AboutSettingsLangs = AboutSettings.AboutSettingsLangs;
            AboutSettingsToBeUpdated.AboutSettingsItems = AboutSettings.AboutSettingsItems;

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateCertificate(AboutSettingsCertificate CertificateToBeUpdated, AboutSettingsCertificate Certificate)
        {
            CertificateToBeUpdated = Certificate;
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateItem(AboutSettingsItem ItemToBeUpdated, AboutSettingsItem Item)
        {
            ItemToBeUpdated = Item;
            ItemToBeUpdated.AboutSettingsItemLangs = Item.AboutSettingsItemLangs;
            await _unitOfWork.CommitAsync();
        }
    }
}