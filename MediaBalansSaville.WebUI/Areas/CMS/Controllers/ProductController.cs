
using System.Linq;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using MediaBalansSaville.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using MediaBalansSaville.Core.Services;
using System;
using Microsoft.AspNetCore.Http;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ICategoryLangService _categoyrLangService;
        private readonly IProductService _productService;
        private readonly IImage _image;

        public ProductController(IImage image,
                                ILangService langService,
                                ICategoryService categoryService,
                                ICategoryLangService categoyrLangService,
                                IProductService productService)
        {
            this._categoryService = categoryService;
            this._categoyrLangService = categoyrLangService;
            this._productService = productService;
            this._image = image;
        }
        [Route("/cms/mehsullar")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _productService.GetAllProducts());
        }

        [Route("/cms/mehsullar/yarat")]
        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new ProductCreateVM
            {
                Categories = await _categoyrLangService.GetAllCategoryLangsFor("product")
            };
            return View(productCreateVM);
        }

        [Route("/cms/mehsullar/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM, List<ProductLang> productLangs, List<SeoLang> seoLangs)
        {
            if (!ModelState.IsValid) return View(productCreateVM);
            if (!_image.IsImageValid(productCreateVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(productCreateVM);
            }
            if (productCreateVM.PhotoFiles != null)
            {
                foreach (var photoFile in productCreateVM.PhotoFiles)
                {
                    if (!_image.IsImageValid(photoFile))
                    {
                        ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                        return View(productCreateVM);
                    }
                }
            }

            Category category = await _categoryService.GetCategoryByCategoryLangId(productCreateVM.CategoryId);
            Product newProduct = new()
            {
                CategoryId = category.Id,
                Category = category,
                SlugUrl = UrlSeoHelper.UrlSeo(productLangs.FirstOrDefault(x => x.LangId == 1).Name.Trim() +" "+ category.CategoryLangs.FirstOrDefault(x => x.LangId == 1).Name),
                IsActive = productCreateVM.IsActive
            };
            List<ProductPhoto> productPhotos = new List<ProductPhoto>();

            ProductPhoto newMainProductPhoto = new ProductPhoto
            {
                PhotoUrl = await _image.UploadForProductAsync(productCreateVM.MainPhotoFile, -1, newProduct.SlugUrl, false, "files", "product"),
                IsCover = true,
                ProductId = newProduct.Id
            };
            productPhotos.Add(newMainProductPhoto);
            if (productCreateVM.NutritionFactPhotoFile != null)
            {
                ProductPhoto newNutritionProductPhoto = new ProductPhoto
                {
                    PhotoUrl = await _image.UploadForProductAsync(productCreateVM.NutritionFactPhotoFile, -1, newProduct.SlugUrl, false, "files", "product"),
                    IsNutrition = true,
                    ProductId = newProduct.Id
                };
                productPhotos.Add(newNutritionProductPhoto);
            }
            if (productCreateVM.PhotoFiles != null)
            {
                for (int i = 0; i < productCreateVM.PhotoFiles.Count; i++)
                {
                    var item = productCreateVM.PhotoFiles.ElementAtOrDefault(i);
                    ProductPhoto newProductPhoto = new()
                    {
                        PhotoUrl = await _image.UploadForProductAsync(item, i, newProduct.SlugUrl, true, "files", "product"),
                        ProductId = newProduct.Id
                    };
                    productPhotos.Add(newProductPhoto);
                }
            }
            newProduct.ProductPhotos = productPhotos;


            Seo newProductSeo = new Seo
            {
               SlugUrl = newProduct.SlugUrl,
               IsActive = true,
               UniqueId = Guid.NewGuid().ToString().Replace("-", "").GetHashCode(),
               Page = "Product",
               IsProduct = true
            };

            List<SeoLang> newProductSeoLangs = new List<SeoLang>();
            foreach (var item in seoLangs)
            {
                newProductSeoLangs.Add(new SeoLang()
                {
                    Title = item.Title,
                    Keys = item.Keys,
                    Desc = item.Desc,
                    SeoId = newProductSeo.Id,
                    LangId = item.LangId
                });
            }
            newProductSeo.SeoLangs = newProductSeoLangs;  
            newProduct.UniqueId = newProductSeo.UniqueId;
            newProduct.ProductSeo = newProductSeo;

            foreach (var item in productLangs)
            {
                newProduct.ProductLangs.Add(new ProductLang()
                {
                    Name = item.Name,
                    Details = item.Details,
                    ProductId = newProduct.Id,
                    LangId = item.LangId
                });
            }
            await _productService.CreateProduct(newProduct);

            return RedirectToAction("Index", "Product");
        }
        [Route("/cms/mehsullar/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Product productFromDb = await _productService.GetProductById(id);
            if (productFromDb == null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                SlugUrl = productFromDb.SlugUrl,
                PhotoUrl = productFromDb.ProductPhotos.FirstOrDefault(x => x.IsCover == true).PhotoUrl,
                Categories = await _categoyrLangService.GetAllCategoryLangsFor("product"),
                ProductLangs = productFromDb.ProductLangs.ToList(),
                SeoLangs = productFromDb.ProductSeo.SeoLangs.ToList(),
                IsActive = productFromDb.IsActive
            };
            
            if(productFromDb.ProductPhotos.Any(x => x.IsNutrition == true))
                productUpdateVM.NutritionFactsPhotoUrl = productFromDb.ProductPhotos.FirstOrDefault(x => x.IsNutrition == true).PhotoUrl;
            foreach (var item in productFromDb.ProductPhotos.Where(x => x.IsCover == false && x.IsNutrition == false).ToList())
                productUpdateVM.PhotoUrls.Add(item.PhotoUrl);
            return View(productUpdateVM);
        }


        [Route("/cms/mehsullar/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ProductUpdateVM productUpdateVM)
        {
            if (id == 0) return BadRequest();
            Product productFromDb = await _productService.GetProductById(id);
            Product productFromVm = productFromDb;
            if (productFromDb == null) return NotFound();
            if (!ModelState.IsValid) return View(productUpdateVM);
            if (productUpdateVM.MainPhotoFile != null)
            {
                if (!_image.IsImageValid(productUpdateVM.MainPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(productUpdateVM);
                }
                else
                {
                    _image.Delete("files", "product", productFromVm.ProductPhotos.FirstOrDefault(x => x.IsCover == true).PhotoUrl);
                    productFromVm.ProductPhotos.FirstOrDefault(x => x.IsCover == true).PhotoUrl = await _image.UploadForProductAsync(productUpdateVM.MainPhotoFile, -1, productFromVm.SlugUrl, false, "files", "product");
                }
            }
            if (productUpdateVM.NutritionFactPhotoFile != null)
            {
                if (!_image.IsImageValid(productUpdateVM.NutritionFactPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(productUpdateVM);
                }
                else
                {
                    _image.Delete("files", "product", productFromVm.ProductPhotos.FirstOrDefault(x => x.IsNutrition == true).PhotoUrl);
                    productFromVm.ProductPhotos.FirstOrDefault(x => x.IsNutrition == true).PhotoUrl = await _image.UploadForProductAsync(productUpdateVM.NutritionFactPhotoFile, -1, productFromVm.SlugUrl, false, "files", "product");
                }
            }

            // productFromVm.SlugUrl = UrlSeoHelper.UrlSeo(productUpdateVM.ProductLangs.FirstOrDefault(x => x.LangId == 1).Name.Trim());
            productFromVm.IsActive = productUpdateVM.IsActive;
            Category category = await _categoryService.GetCategoryByCategoryLangId(productUpdateVM.CategoryId);
            productFromVm.Category = category;
            productFromVm.CategoryId = category.Id;

            if (productUpdateVM.PhotoFiles != null)
            {
                foreach (var item in productFromVm.ProductPhotos.Where(x => x.IsCover == false && x.IsNutrition == false))
                {
                    productFromVm.ProductPhotos.Remove(item);
                    _image.Delete("files", "product", item.PhotoUrl);
                }

                for (int i = 0; i < productUpdateVM.PhotoFiles.Count(); i++)
                {
                    var item = productUpdateVM.PhotoFiles.ElementAtOrDefault(i);
                    ProductPhoto newProductPhoto = new ProductPhoto
                    {
                        PhotoUrl = await _image.UploadForProductAsync(item, i, productFromVm.SlugUrl, true, "files", "product"),
                        ProductId = productFromVm.Id
                    };
                    productFromVm.ProductPhotos.Add(newProductPhoto);
                }
            }

            int count = 0;
            foreach (var item in productFromVm.ProductSeo.SeoLangs)
            {                
                item.Title = productUpdateVM.SeoLangs.ElementAt(count).Title;
                item.Keys = productUpdateVM.SeoLangs.ElementAt(count).Keys;
                item.Desc = productUpdateVM.SeoLangs.ElementAt(count).Desc;
                count++;
            }

            count = 0;
            foreach (var item in productFromVm.ProductLangs)
            {
                item.Name = productUpdateVM.ProductLangs.ElementAt(count).Name;
                item.Details = productUpdateVM.ProductLangs.ElementAt(count).Details;
                count++;
            }
            await _productService.UpdateProduct(productFromDb, productFromVm);

            return RedirectToAction("Index", "Product");
        }

        [Route("/cms/mehsullar/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            Product productFromDb = await _productService.GetProductById(id);
            if (id == 0 && productFromDb != null) return BadRequest();
            
            foreach (var item in productFromDb.ProductPhotos.Where(x => x.IsCover == false && x.IsNutrition == false))
            {
                _image.DeleteForProduct("files", "product", productFromDb.SlugUrl ,item.PhotoUrl);
            }
            await _productService.DeleteProduct(productFromDb);            

            return RedirectToAction("Index", "Product");
        }

        #region 3D Pictures of Product
        
        [Route("/cms/mehsullar/sekiller/{id}")]
        public async Task<IActionResult> ProductPhoto(int id)
        {            
            Product product = await _productService.GetProductById(id);
            ViewBag.ProductId = product.Id;
            ViewBag.Name = product.ProductLangs.FirstOrDefault(x => x.Lang.Code == "az").Name;
            return View(product.ProductPhotos.Where(x => x.IsCover == false && x.IsNutrition == false));
        }
        [Route("/cms/mehsullar/sekiller/yarat/{id}")]
        public IActionResult CreatePhoto(int id)
        {
            ProductPhotoVM photoVM = new ProductPhotoVM() { ProductId = id };
            return View(photoVM);
        }

        [Route("/cms/mehsullar/sekiller/yarat/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePhoto(int id, ProductPhotoVM photoVM)
        {
            if (!ModelState.IsValid) return View(photoVM);

            if (!_image.IsImageValid(photoVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(photoVM);
            }

            Product productFromDb = await _productService.GetProductById(id);
            var index = productFromDb.ProductPhotos.Where(x => x.IsCover == false && x.IsNutrition == false).Count();
            ProductPhoto newProductPhoto = new ProductPhoto
            {
                IndexNo = index + 1,
                PhotoUrl = await _image.UploadForProductAsync(photoVM.MainPhotoFile, index + 1, productFromDb.SlugUrl, true, "files", "product"),
                ProductId = productFromDb.Id
            };

            await _productService.CreateProductPhoto(newProductPhoto);

            return RedirectToAction("ProductPhoto", "Product", new {@id=productFromDb.Id});
        }

        [Route("/cms/mehsullar/sekiller/duzeliset/{id}")]
        public async Task<IActionResult> UpdatePhoto(int id)
        {
            if (id == 0) return BadRequest();
            ProductPhoto productFromDb = await _productService.GetProductPhotoById(id);
            if (productFromDb == null) return NotFound();
            ProductPhotoVM photoVM = new ProductPhotoVM() { ProductId = productFromDb.ProductId };
            return View(photoVM);
        }

        [Route("/cms/mehsullar/sekiller/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePhoto(int id, ProductPhotoVM photoVM)
        {
            if (id == 0) return BadRequest();
            ProductPhoto productFromDb = await _productService.GetProductPhotoById(id);
            if (productFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(photoVM);

            if (photoVM.MainPhotoFile != null)
            {
                if (!_image.IsImageValid(photoVM.MainPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(photoVM);
                }
                else
                {
                    _image.DeleteForProduct("files", "product", productFromDb.Product.SlugUrl, productFromDb.PhotoUrl);
                    productFromDb.PhotoUrl = await _image.UploadForProductAsync(photoVM.MainPhotoFile, productFromDb.IndexNo, productFromDb.Product.SlugUrl, true, "files", "product");
                }
            }
            
            await _productService.UpdateProductPhoto(productFromDb, productFromDb);

            return RedirectToAction("ProductPhoto", "Product", new {@id=productFromDb.Product.Id});
        }

        [Route("/cms/mehsullar/sekiller/kaldir/{id}")]
        public async Task<IActionResult> DeletePhoto(int id)
        {
            if (id == 0) return BadRequest();
            ProductPhoto productFromDb = await _productService.GetProductPhotoById(id);
            _image.DeleteForProduct("files", "product", productFromDb.Product.SlugUrl, productFromDb.PhotoUrl);
            await _productService.DeleteProductPhoto(productFromDb);
            

            return RedirectToAction("ProductPhoto", "Product", new {@id=productFromDb.ProductId});
        }
        #endregion
    }
}
