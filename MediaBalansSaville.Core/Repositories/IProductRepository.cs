using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductBySlugUrlAndUrlId(string slugurl, int urlid);
    }
}