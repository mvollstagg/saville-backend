using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class ExportationRepository : Repository<Exportation>, IExportationRepository
    {
        public ExportationRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<Exportation> GetExportations()
        {
            return await ApplicationDbContext.Exportations
                .Include(a => a.ExportationLangs)
                    .ThenInclude(b => b.Lang)
                .Include(b => b.ExportationCountries)
                .FirstOrDefaultAsync();
        }
    }
}