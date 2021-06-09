using System.Collections.Generic;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.Core.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();        
        Task<Product> GetProductById(int id);
        Task<Product> GetProductBySlugUrlAndUrlId(string slugurl, int urlid);
        Task<Product> CreateProduct(Product newProduct);
        Task UpdateProduct(Product productToBeUpdated, Product product);
        Task DeleteProduct(Product product);



        Task<ProductPhoto> GetProductPhotoById(int id);
        Task<ProductPhoto> CreateProductPhoto(ProductPhoto newProductPhoto);
        Task UpdateProductPhoto(ProductPhoto ProductPhotoToBeUpdated, ProductPhoto ProductPhoto);
        Task DeleteProductPhoto(ProductPhoto ProductPhoto);
    }
}