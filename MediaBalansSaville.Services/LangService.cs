using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class LangService : ILangService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public LangService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Lang> CreateLang(Lang newLang)
        {
            newLang.UrlId = _unitOfWork.Langs.TotalCount() + 1;
            await _unitOfWork.Langs.AddAsync(newLang);
            await _unitOfWork.CommitAsync();
            return newLang;
        }

        public async Task DeleteLang(Lang lang)
        {
            _unitOfWork.Langs.Remove(lang);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Lang>> GetAllLangs()
        {
            return await _unitOfWork.Langs.GetAllAsync();
        }

        public async Task<Lang> GetLangWithCode(string code)
        {
            return await _unitOfWork.Langs.GetLangWithCode(code);
        }

        public async Task<Lang> GetLangWithId(int id)
        {
            return await _unitOfWork.Langs.GetByIdAsync(id);
        }

        public async Task UpdateLang(Lang langToBeUpdated, Lang lang)
        {
            langToBeUpdated.Name = lang.Name;
            langToBeUpdated.Code = lang.Code;
            langToBeUpdated.SlugUrl = lang.Name.Trim();
            langToBeUpdated.IsActive = lang.IsActive;

            await _unitOfWork.CommitAsync();
        }
    }
}