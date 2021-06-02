using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class FAQRepository : Repository<FAQ>, IFAQRepository
    {
        public FAQRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<FAQ>> GetAllFAQs()
        {
            return await ApplicationDbContext.FAQs
                .Include(a => a.FAQLangs)
                    .ThenInclude(b => b.Lang)
                .ToListAsync();
        }

        public async Task<FAQ> GetFAQById(int id)
        {
            return await ApplicationDbContext.FAQs
                .Include(a => a.FAQLangs)
                    .ThenInclude(b => b.Lang)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}