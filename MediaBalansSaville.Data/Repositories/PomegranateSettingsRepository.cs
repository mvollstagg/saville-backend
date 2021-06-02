using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class PomegranateSettingsRepository : Repository<PomegranateSettings>, IPomegranateRepository
    {
        public PomegranateSettingsRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<PomegranateSettings> GetPomegranateSettings()
        {
            return await ApplicationDbContext.PomegranateSettings
                .Include(a => a.PomegranateSettingsLangs)
                    .ThenInclude(b => b.Lang)
                .FirstOrDefaultAsync();
        }
    }
}