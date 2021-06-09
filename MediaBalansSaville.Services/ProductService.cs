using MediaBalansSaville.Core;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MediaBalansSaville.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateProduct(Product newProduct)
        {
            newProduct.UrlId = _unitOfWork.Products.TotalCount() + 1;
            await _unitOfWork.Products.AddAsync(newProduct);
            await _unitOfWork.CommitAsync();
            return newProduct;
        }

        public async Task<ProductPhoto> CreateProductPhoto(ProductPhoto newProductPhoto)
        {
            await _unitOfWork.ProductPhotos.AddAsync(newProductPhoto);
            await _unitOfWork.CommitAsync();
            return newProductPhoto;
        }

        public async Task DeleteProduct(Product product)
        {
            _unitOfWork.Seos.Remove(product.ProductSeo);
            _unitOfWork.Products.Remove(product);

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteProductPhoto(ProductPhoto ProductPhoto)
        {
            _unitOfWork.ProductPhotos.Remove(ProductPhoto);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _unitOfWork.Products.GetAllProducts();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _unitOfWork.Products.GetProductById(id);
        }
        public async Task<ProductPhoto> GetProductPhotoById(int id)
        {
            return await _unitOfWork.ProductPhotos.GetByIdAsync(id);
        }

        public async Task<Product> GetProductBySlugUrlAndUrlId(string slugurl, int urlid)
        {
            return await _unitOfWork.Products.GetProductBySlugUrlAndUrlId(slugurl, urlid);
        }

        public async Task UpdateProduct(Product productToBeUpdated, Product product)
        {
            productToBeUpdated.ProductLangs = product.ProductLangs;
            productToBeUpdated.ProductSeo = product.ProductSeo;
            productToBeUpdated = product;
            productToBeUpdated.SlugUrl = product.SlugUrl;
            productToBeUpdated.IsActive = product.IsActive;

            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateProductPhoto(ProductPhoto ProductPhotoToBeUpdated, ProductPhoto ProductPhoto)
        {
            ProductPhotoToBeUpdated = ProductPhoto;

            await _unitOfWork.CommitAsync();
        }
    }
}