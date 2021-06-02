using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class SiteSettingsService : ISiteSettingsService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public SiteSettingsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<SiteSettings> CreateSiteSettings(SiteSettings newSiteSettings)
        {
            await _unitOfWork.SiteSettings.AddAsync(newSiteSettings);
            await _unitOfWork.CommitAsync();
            return newSiteSettings;
        }

        public async Task<SiteSettings> GetSiteSettings()
        {
            return await _unitOfWork.SiteSettings.GetSiteSettings();
        }

        public async Task UpdateSiteSettings(SiteSettings SiteSettingsToBeUpdated, SiteSettings SiteSettings)
        {
            SiteSettingsToBeUpdated.FacebookURL = SiteSettings.FacebookURL;
            SiteSettingsToBeUpdated.InstagramURL = SiteSettings.InstagramURL;
            SiteSettingsToBeUpdated.PhoneNumber = SiteSettings.PhoneNumber;
            SiteSettingsToBeUpdated.FacebookPixel = SiteSettings.FacebookPixel;
            SiteSettingsToBeUpdated.GoogleAnalyticsCode = SiteSettings.GoogleAnalyticsCode;
            SiteSettingsToBeUpdated.SiteSettingsLangs = SiteSettings.SiteSettingsLangs;

            await _unitOfWork.CommitAsync();
        }
    }
}