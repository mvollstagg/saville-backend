using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class ExportationCountryRepository : Repository<ExportationCountry>, IExportationCountryRepository
    {
        public ExportationCountryRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}