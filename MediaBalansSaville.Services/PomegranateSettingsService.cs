using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class PomegranateSettingsService : IPomegranateService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PomegranateSettingsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<PomegranateSettings> CreatePomegranateSettings(PomegranateSettings newPomegranateSettings)
        {
            await _unitOfWork.PomegranateSettings.AddAsync(newPomegranateSettings);
            await _unitOfWork.CommitAsync();
            return newPomegranateSettings;
        }

        public async Task<PomegranateSettings> GetPomegranateSettings()
        {
            return await _unitOfWork.PomegranateSettings.GetPomegranateSettings();
        }

        public async Task UpdatePomegranateSettings(PomegranateSettings PomegranateSettingsToBeUpdated, PomegranateSettings PomegranateSettings)
        {
            PomegranateSettingsToBeUpdated = PomegranateSettings;
            PomegranateSettingsToBeUpdated.PomegranateSettingsLangs = PomegranateSettings.PomegranateSettingsLangs;

            await _unitOfWork.CommitAsync();
        }
    }
}