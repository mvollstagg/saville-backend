using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;
using System.Linq;

namespace MediaBalansSaville.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await ApplicationDbContext.Categories
                .Include(a => a.CategoryLangs)
                    .ThenInclude(b => b.Lang)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByCategoryLangId(int id)
        {
            return await ApplicationDbContext.Categories
                .Include(a => a.CategoryLangs)
                    .ThenInclude(b => b.Lang)
                .FirstOrDefaultAsync(x => x.CategoryLangs.FirstOrDefault().Id == id);
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await ApplicationDbContext.Categories
                .Include(a => a.CategoryLangs)
                    .ThenInclude(b => b.Lang)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}