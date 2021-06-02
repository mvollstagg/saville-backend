using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class AboutSettingsRepository : Repository<AboutSettings>, IAboutSettingsRepository
    {
        public AboutSettingsRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<AboutSettings> GetAboutSettings()
        {
            return await ApplicationDbContext.AboutSettings
                .Include(a => a.AboutSettingsLangs)
                    .ThenInclude(b => b.Lang)
                .Include(b => b.AboutSettingsCertificates)
                .Include(c => c.AboutSettingsItems)
                    .ThenInclude(d => d.AboutSettingsItemLangs)
                        .ThenInclude(e => e.Lang)
                .FirstOrDefaultAsync();
        }
    }
}