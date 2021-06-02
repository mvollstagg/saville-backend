using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class ReceiptRepository : Repository<Receipt>, IReceiptRepository
    {
        public ReceiptRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<Receipt>> GetAllReceipts()
        {
            return await ApplicationDbContext.Receipts
                .Include(a => a.ReceiptLangs)
                    .ThenInclude(b => b.Lang)
                .Include(a => a.ReceiptPhotos)
                .Include(a => a.Category)
                    .ThenInclude(b => b.CategoryLangs)
                .ToListAsync();
        }

        public async Task<Receipt> GetReceiptById(int id)
        {
            return await ApplicationDbContext.Receipts
                .Include(a => a.ReceiptLangs)
                    .ThenInclude(b => b.Lang)
                .Include(a => a.ReceiptPhotos)
                .Include(a => a.Category)
                    .ThenInclude(b => b.CategoryLangs)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Receipt> GetReceiptBySlugUrlAndUrlId(string slugurl, int urlid)
        {
            return await ApplicationDbContext.Receipts
                .Include(a => a.ReceiptLangs)
                    .ThenInclude(b => b.Lang)
                .Include(a => a.ReceiptPhotos)
                .Include(a => a.Category)
                    .ThenInclude(b => b.CategoryLangs)
                .FirstOrDefaultAsync(x => x.SlugUrl == slugurl && x.UrlId == urlid);
        }
    }
}