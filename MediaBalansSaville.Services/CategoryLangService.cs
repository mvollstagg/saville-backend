using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class CategoryLangService : ICategoryLangService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CategoryLangService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<CategoryLang>> GetAllCategoryLangs()
        {
            return await _unitOfWork.CategoryLangs.GetAllCategoryLangs();
        }

        public async Task<List<CategoryLang>> GetAllCategoryLangsFor(string predicate)
        {
            return await _unitOfWork.CategoryLangs.GetAllCategoryLangsFor(predicate);
        }

        public async Task<CategoryLang> GetCategoryLangById(int id)
        {
            return await _unitOfWork.CategoryLangs.GetCategoryLangById(id);
        }
    }
}