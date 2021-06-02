using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class SiteSettingsRepository : Repository<SiteSettings>, ISiteSettingsRepository
    {
        public SiteSettingsRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<SiteSettings> GetSiteSettings()
        {
            return await ApplicationDbContext.SiteSettings
                .Include(a => a.SiteSettingsLangs)
                    .ThenInclude(b => b.Lang)                
                .FirstOrDefaultAsync();
        }
    }
}