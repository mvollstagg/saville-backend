
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
        private readonly ILangService _langService;
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
            this._langService = langService;
            this._productService = productService;
            this._image = image;
        }
        [Route("/cms/məhsullar")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _productService.GetAllProducts());
        }

        [Route("/cms/məhsullar/yarat")]
        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new ProductCreateVM
            {
                Categories = await _categoyrLangService.GetAllCategoryLangsFor("product")

            };
            return View(productCreateVM);
        }

        [Route("/cms/məhsullar/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM, List<ProductLang> ProductLangs)
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

            Lang azLang = await _langService.GetLangWithCode("az");
            Lang ruLang = await _langService.GetLangWithCode("ru");
            Lang enLang = await _langService.GetLangWithCode("en");

            if (azLang == null && ruLang == null && enLang == null)
            {
                ModelState.AddModelError("", "Öncə məlumat bazasına dillər əlavə edilməlidir !");
                return View(productCreateVM);
            }
            Category category = await _categoryService.GetCategoryByCategoryLangId(productCreateVM.CategoryId);
            Product newProduct = new Product
            {
                CategoryId = category.Id,
                Category = category,
                SlugUrl = UrlSeoHelper.UrlSeo(productCreateVM.NameAZ.Trim()),
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
                for (int i = 0; i < productCreateVM.PhotoFiles.Count(); i++)
                {
                    var item = productCreateVM.PhotoFiles.ElementAtOrDefault(i);
                    ProductPhoto newProductPhoto = new ProductPhoto
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
                SlugUrl = UrlSeoHelper.UrlSeo(productCreateVM.NameAZ.Trim()),
                IsActive = true,
                UniqueId = Guid.NewGuid().ToString().Replace("-", "").GetHashCode(),
                Page = productCreateVM.NameAZ.Trim(),
                IsBlog = true
            };
            List<SeoLang> seoLangs = new List<SeoLang>();
            SeoLang newSeoLangAZ = new SeoLang
            {
                SeoId = newProductSeo.Id,
                Title = productCreateVM.SeoTitleAZ,
                Keys = productCreateVM.SeoKeysAZ,
                Desc = productCreateVM.SeoDescAZ,
                LangId = azLang.Id
            };
            SeoLang newSeoLangRU = new SeoLang
            {
                SeoId = newProductSeo.Id,
                Title = productCreateVM.SeoTitleRU,
                Keys = productCreateVM.SeoKeysRU,
                Desc = productCreateVM.SeoDescRU,
                LangId = ruLang.Id
            };
            SeoLang newSeoLangEN = new SeoLang
            {
                SeoId = newProductSeo.Id,
                Title = productCreateVM.SeoTitleEN,
                Keys = productCreateVM.SeoKeysEN,
                Desc = productCreateVM.SeoDescEN,
                LangId = enLang.Id
            };
            newProduct.UniqueId = newProductSeo.UniqueId;
            seoLangs.Add(newSeoLangAZ);
            seoLangs.Add(newSeoLangRU);
            seoLangs.Add(newSeoLangEN);
            newProductSeo.SeoLangs = seoLangs;
            newProduct.ProductSeo = newProductSeo;


            foreach (var item in ProductLangs)
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
        [Route("/cms/məhsullar/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Product productFromDb = await _productService.GetProductById(id);
            Seo seoFromDb = productFromDb.ProductSeo;
            if (productFromDb == null) return NotFound();

            ProductUpdateVM productUpdateVM = new ProductUpdateVM
            {
                NameAZ = productFromDb.ProductLangs.FirstOrDefault(x => x.Lang.Code == "az").Name,
                NameRU = productFromDb.ProductLangs.FirstOrDefault(x => x.Lang.Code == "ru").Name,
                NameEN = productFromDb.ProductLangs.FirstOrDefault(x => x.Lang.Code == "en").Name,
                SeoTitleAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Title,
                SeoKeysAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Keys,
                SeoDescAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Desc,
                SeoTitleRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Title,
                SeoKeysRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Keys,
                SeoDescRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Desc,
                SeoTitleEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Title,
                SeoKeysEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Keys,
                SeoDescEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Desc,
                PhotoUrl = productFromDb.ProductPhotos.FirstOrDefault(x => x.IsCover == true).PhotoUrl,
                NutritionFactsPhotoUrl = productFromDb.ProductPhotos.FirstOrDefault(x => x.IsNutrition == true).PhotoUrl,
                IsActive = productFromDb.IsActive
            };
            productUpdateVM.Categories = await _categoyrLangService.GetAllCategoryLangsFor("product");

            return View();
        }


        [Route("/cms/məhsullar/duzeliset/{id}")]
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

            productFromVm.SlugUrl = UrlSeoHelper.UrlSeo(productUpdateVM.NameAZ.Trim());
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

            Seo seoFromDb = productFromVm.ProductSeo;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Title = productUpdateVM.SeoTitleAZ;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Keys = productUpdateVM.SeoKeysAZ;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Desc = productUpdateVM.SeoDescAZ;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Title = productUpdateVM.SeoTitleRU;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Keys = productUpdateVM.SeoKeysRU;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Desc = productUpdateVM.SeoDescRU;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Title = productUpdateVM.SeoTitleEN;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Keys = productUpdateVM.SeoKeysEN;
            seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Desc = productUpdateVM.SeoDescEN;

            productFromVm.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Name = productUpdateVM.NameAZ.Trim();
            productFromVm.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Name = productUpdateVM.NameRU.Trim();
            productFromVm.ProductLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Name = productUpdateVM.NameEN.Trim();
            await _productService.UpdateProduct(productFromDb, productFromVm);

            return RedirectToAction("Index", "Product");
        }

        [Route("/cms/məhsullar/kaldir/{id}")]
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
