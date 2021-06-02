using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Data.DAL;

namespace MediaBalansSaville.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context) { }
        

        public ApplicationDbContext ApplicationDbContext
        {
            get { return _context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await ApplicationDbContext.Products
                .Include(a => a.ProductLangs)
                    .ThenInclude(b => b.Lang)
                .Include(a => a.Category)
                    .ThenInclude(b => b.CategoryLangs)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await ApplicationDbContext.Products
                .Include(a => a.ProductLangs)
                    .ThenInclude(b => b.Lang)
                .Include(a => a.Category)
                    .ThenInclude(b => b.CategoryLangs)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Product> GetProductBySlugUrlAndUrlId(string slugurl, int urlid)
        {
            return await ApplicationDbContext.Products
                .Include(a => a.ProductLangs)
                    .ThenInclude(b => b.Lang)
                .Include(a => a.Category)
                    .ThenInclude(b => b.CategoryLangs)
                .FirstOrDefaultAsync(x => x.SlugUrl == slugurl && x.UrlId == urlid);
        }
    }
}