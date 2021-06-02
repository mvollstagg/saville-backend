
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface ISiteSettingsRepository : IRepository<SiteSettings>
    {
        Task<SiteSettings> GetSiteSettings();
        
    }
}