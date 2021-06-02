using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<List<Category>> GetAllCategories();   
        Task<Category> GetCategoryById(int id);
        Task<Category> GetCategoryByCategoryLangId(int id);
    }
}