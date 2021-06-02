using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;
using System.Linq;

namespace MediaBalansSaville.Data.Repositories
{
    public class SeoRepository : Repository<Seo>, ISeoRepository
    {
        public SeoRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }


        public async Task<IEnumerable<Seo>> GetAllSeos()
        {
            return await ApplicationDbContext.Seos
                .Where(x => x.IsBlog == false && x.IsProduct == false && x.IsReceipt == false)
                .Include(a => a.SeoLangs)
                    .ThenInclude(b => b.Lang)                
                .ToListAsync();
        }

        public async Task<Seo> GetSeoById(int id)
        {
            return await ApplicationDbContext.Seos
                .Where(x => x.IsBlog == false && x.IsProduct == false && x.IsReceipt == false)
                .Include(a => a.SeoLangs)
                    .ThenInclude(b => b.Lang)                
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Seo> GetSeoByPageName(string pageName)
        {
            return await ApplicationDbContext.Seos
                .Where(x => x.IsBlog == false && x.IsProduct == false && x.IsReceipt == false)
                .Include(a => a.SeoLangs)
                    .ThenInclude(b => b.Lang)                
                .FirstOrDefaultAsync(x => x.Page == pageName);
        }

        public async Task<Seo> GetSeoByUniqueId(int id)
        {
            return await ApplicationDbContext.Seos
                .Where(x => x.IsBlog == true || x.IsProduct == true || x.IsReceipt == true)
                .Include(a => a.SeoLangs)
                    .ThenInclude(b => b.Lang)                
                .FirstOrDefaultAsync(x => x.UniqueId == id);
        }
    }
}