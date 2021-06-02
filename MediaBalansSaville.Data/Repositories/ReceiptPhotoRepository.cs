
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class ReceiptPhotoRepository : Repository<ReceiptPhoto>, IReceiptPhotoRepository
    {
        public ReceiptPhotoRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}