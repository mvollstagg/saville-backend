
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IPomegranateService
    {     
        Task<PomegranateSettings> GetPomegranateSettings();
        Task<PomegranateSettings> CreatePomegranateSettings(PomegranateSettings newPomegranateSettings);
        Task UpdatePomegranateSettings(PomegranateSettings PomegranateSettingsToBeUpdated, PomegranateSettings PomegranateSettings);
    }
}