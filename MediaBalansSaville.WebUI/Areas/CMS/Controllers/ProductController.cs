
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
                SlugUrl = UrlSeoHelper.UrlSeo(productLangs.FirstOrDefault(x => x.LangId == 1).Name.Trim()),
                IsActive = productCreateVM.IsActive
            };
            List<ProductPhoto> productPhotos = new List<ProductPhoto>();

            ProductPhoto newMainProductPhoto = new ProductPhoto
            {
                PhotoUrl = await _image.UploadAsync(productCreateVM.MainPhotoFile, "files", "product"),
                IsCover = true,
                ProductId = newProduct.Id
            };
            productPhotos.Add(newMainProductPhoto);
            ProductPhoto newNutritionProductPhoto = new ProductPhoto
            {
                PhotoUrl = await _image.UploadAsync(productCreateVM.NutritionFactPhotoFile, "files", "product"),
                IsNutrition = true,
                ProductId = newProduct.Id
            };
            productPhotos.Add(newNutritionProductPhoto);

            if (productCreateVM.PhotoFiles != null)
            {
                for (int i = 0; i < productCreateVM.PhotoFiles.Count; i++)
                {
                    var item = productCreateVM.PhotoFiles.ElementAtOrDefault(i);
                    ProductPhoto newProductPhoto = new()
                    {
                        PhotoUrl = await _image.UploadAsync(item, "files", "product"),
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
                PhotoUrl = productFromDb.ProductPhotos.FirstOrDefault(x => x.IsCover == true).PhotoUrl,
                NutritionFactsPhotoUrl = productFromDb.ProductPhotos.FirstOrDefault(x => x.IsNutrition == true).PhotoUrl,
                Categories = await _categoyrLangService.GetAllCategoryLangsFor("product"),
                ProductLangs = productFromDb.ProductLangs.ToList(),
                SeoLangs = productFromDb.ProductSeo.SeoLangs.ToList(),
                IsActive = productFromDb.IsActive
            };
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
                    productFromVm.ProductPhotos.FirstOrDefault(x => x.IsCover == true).PhotoUrl = await _image.UploadAsync(productUpdateVM.MainPhotoFile, "files", "product");
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
                    productFromVm.ProductPhotos.FirstOrDefault(x => x.IsNutrition == true).PhotoUrl = await _image.UploadAsync(productUpdateVM.NutritionFactPhotoFile, "files", "product");
                }
            }

            productFromVm.SlugUrl = UrlSeoHelper.UrlSeo(productUpdateVM.ProductLangs.FirstOrDefault(x => x.LangId == 1).Name.Trim());
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
                        PhotoUrl = await _image.UploadAsync(item, "files", "product"),
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
                count++;
            }
            await _productService.UpdateProduct(productFromDb, productFromVm);

            return RedirectToAction("Index", "Product");
        }

        [Route("/cms/mehsullar/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Product productFromDb = await _productService.GetProductById(id);
            await _productService.DeleteProduct(productFromDb);
            foreach (var item in productFromDb.ProductPhotos)
            {
                _image.Delete("files", "product", item.PhotoUrl);
            }

            return RedirectToAction("Index", "Product");
        }
    }
}
