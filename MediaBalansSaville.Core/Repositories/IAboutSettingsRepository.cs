
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface IAboutSettingsRepository : IRepository<AboutSettings>
    {
        Task<AboutSettings> GetAboutSettings();
        
    }
}