using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface ICategoryLangRepository : IRepository<CategoryLang>
    {
        Task<List<CategoryLang>> GetAllCategoryLangs(); 
        Task<List<CategoryLang>> GetAllCategoryLangsFor(string predicate);     
        Task<CategoryLang> GetCategoryLangById(int id);
    }
}