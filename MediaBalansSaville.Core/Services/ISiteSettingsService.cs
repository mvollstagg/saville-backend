
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface ISiteSettingsService
    {     
        Task<SiteSettings> GetSiteSettings();
        Task<SiteSettings> CreateSiteSettings(SiteSettings newSiteSettings);
        Task UpdateSiteSettings(SiteSettings SiteSettingsToBeUpdated, SiteSettings SiteSettings);
    }
}