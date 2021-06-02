using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;
using System.Linq;

namespace MediaBalansSaville.Data.Repositories
{
    public class CategoryLangRepository : Repository<CategoryLang>, ICategoryLangRepository
    {
        public CategoryLangRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<List<CategoryLang>> GetAllCategoryLangs()
        {
            return await ApplicationDbContext.CategoryLangs
                .Include(b => b.Lang)
                .ToListAsync();
        }

        public async Task<List<CategoryLang>> GetAllCategoryLangsFor(string predicate)
        {
            if(predicate == "product")
            {
                return await ApplicationDbContext.CategoryLangs
                .Where(x => x.Category.IsActive == true && x.Category.IsProduct == true && x.Lang.Code.ToLower() == "az")
                .Include(b => b.Lang)
                .ToListAsync();
            }
            if(predicate == "receipt")
            {
                return await ApplicationDbContext.CategoryLangs
                .Where(x => x.Category.IsActive == true && x.Category.IsReceipt == true && x.Lang.Code.ToLower() == "az")
                .Include(b => b.Lang)
                .ToListAsync();
            }
            return null;
        }

        public async Task<CategoryLang> GetCategoryLangById(int id)
        {
            return await ApplicationDbContext.CategoryLangs
                .Include(a => a.Lang)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}