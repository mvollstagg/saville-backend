
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class ProductPhotoRepository : Repository<ProductPhoto>, IProductPhotoRepository
    {
        public ProductPhotoRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}