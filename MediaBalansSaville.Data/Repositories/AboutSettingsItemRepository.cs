using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;
using System.Collections.Generic;

namespace MediaBalansSaville.Data.Repositories
{
    public class AboutSettingsItemRepository : Repository<AboutSettingsItem>, IAboutSettingsItemRepository
    {
        public AboutSettingsItemRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<AboutSettingsItem>> GetAllItems()
        {
            return await ApplicationDbContext.AboutSettingsItems
                .Include(a => a.AboutSettingsItemLangs)
                    .ThenInclude(b => b.Lang)
                .ToListAsync();
        }

        public async Task<AboutSettingsItem> GetItemById(int id)
        {
            return await ApplicationDbContext.AboutSettingsItems
                .Include(a => a.AboutSettingsItemLangs)
                    .ThenInclude(b => b.Lang)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}