using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategory(Category newCategory)
        {
            newCategory.UrlId = _unitOfWork.Categories.TotalCount() + 1;
            await _unitOfWork.Categories.AddAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return newCategory;
        }

        public async Task DeleteCategory(Category category)
        {
            _unitOfWork.Categories.Remove(category);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.Categories.GetAllCategories();
        }

        public async Task<Category> GetCategoryByCategoryLangId(int id)
        {
            return await _unitOfWork.Categories.GetCategoryByCategoryLangId(id);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _unitOfWork.Categories.GetCategoryById(id);
        }

        public async Task UpdateCategory(Category categoryToBeUpdated, Category category)
        {
            categoryToBeUpdated.CategoryLangs = category.CategoryLangs;
            categoryToBeUpdated.IsProduct = category.IsProduct;
            categoryToBeUpdated.IsReceipt = category.IsReceipt;
            categoryToBeUpdated.SlugUrl = category.SlugUrl;
            categoryToBeUpdated.IsActive = category.IsActive;

            await _unitOfWork.CommitAsync();
        }
    }
}