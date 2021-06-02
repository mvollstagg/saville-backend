using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface ILangService
    {
        Task<IEnumerable<Lang>> GetAllLangs();
        Task<Lang> GetLangWithId(int id);
        Task<Lang> GetLangWithCode(string code);
        Task<Lang> CreateLang(Lang newLang);
        Task UpdateLang(Lang langToBeUpdated, Lang lang);
        Task DeleteLang(Lang lang);        
    }
}