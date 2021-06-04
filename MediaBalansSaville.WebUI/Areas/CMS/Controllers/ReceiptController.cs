using System;
using System.Linq;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using MediaBalansSaville.Services.Utilities;
using Microsoft.AspNetCore.Authorization;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class ReceiptController : Controller
    {
        private readonly ILangService _langService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly ICategoryLangService _categoyrLangService;
        private readonly IReceiptService _receiptService;
        private readonly IReceiptPhotoService _receiptPhotoService;
        private readonly IImage _image;

        public ReceiptController(ILangService langService, 
                                ICategoryService categoryService,
                                IImage image,
                                IReceiptService receiptService,
                                ICategoryLangService categoyrLangService,
                                IReceiptPhotoService receiptPhotoService,
                                IProductService productService)
        {
            this._categoryService = categoryService;
            this._langService = langService;
            this._image = image;
            this._receiptService = receiptService;
            this._categoyrLangService = categoyrLangService;
            this._receiptPhotoService = receiptPhotoService;
            _productService = productService;
        }
        [Route("/cms/Receipt")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _receiptService.GetAllReceipts());
        }

        [Route("/cms/Receipt/yarat")]
        public async Task<IActionResult> Create()
        {
            List<string> products = new List<string>();
            products.Add("1111");
            products.Add("2222");
            products.Remove("1111");

            ReceiptCreateVM receiptCreateVM = new ReceiptCreateVM
            {
                Products = await _productService.GetAllProducts(),
                Categories = await _categoyrLangService.GetAllCategoryLangsFor("receipt")                
            };
            return View(receiptCreateVM);
        }
        [Route("/cms/Receipt/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceiptCreateVM receiptCreateVM, List<ReceiptLang> receiptLangs, List<SeoLang> seoLangs)
        {
            if (!ModelState.IsValid) return View(receiptCreateVM);
            if (!_image.IsImageValid(receiptCreateVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(receiptCreateVM);
            }
            if(receiptCreateVM.PhotoFiles != null)
            {
                foreach (var photoFile in receiptCreateVM.PhotoFiles)
                {
                    if (!_image.IsImageValid(photoFile))
                    {
                        ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                        return View(receiptCreateVM);
                    }
                }
            }
            
            Category category = await _categoryService.GetCategoryByCategoryLangId(receiptCreateVM.CategoryId);
            Receipt newReceipt = new Receipt
            {         
                ProductValues = receiptCreateVM.ProductValues,
                CategoryId = category.Id,
                Category = category, 
                IsBlog = receiptCreateVM.IsBlog,
                IsActive = receiptCreateVM.IsActive                
            };
            newReceipt.SlugUrl = UrlSeoHelper.UrlSeo(receiptLangs.FirstOrDefault(x => x.LangId == 1).Title.Trim());
            List<ReceiptPhoto> receiptPhotos = new List<ReceiptPhoto>();
            ReceiptPhoto newMainReceiptPhoto = new ReceiptPhoto
            {
                PhotoUrl = await _image.UploadAsync(receiptCreateVM.MainPhotoFile, "files", "receipt"),
                IsMain = true,
                ReceiptId= newReceipt.Id
            };
            receiptPhotos.Add(newMainReceiptPhoto);

            if(receiptCreateVM.PhotoFiles != null)
            {
                for (int i=0; i<receiptCreateVM.PhotoFiles.Count(); i++)
                {
                    var item = receiptCreateVM.PhotoFiles.ElementAtOrDefault(i);
                    ReceiptPhoto newReceiptPhoto = new ReceiptPhoto
                    {
                        PhotoUrl = await _image.UploadAsync(item, "files", "receipt"),
                        ReceiptId = newReceipt.Id
                    };
                    receiptPhotos.Add(newReceiptPhoto);
                }
            }
            newReceipt.ReceiptPhotos = receiptPhotos;
            
            Seo newReceiptSeo = new Seo
            {
               SlugUrl = newReceipt.SlugUrl,
               IsActive = true,
               UniqueId = Guid.NewGuid().ToString().Replace("-", "").GetHashCode(),
               Page = "Receipt",
               IsReceipt = true
            };

            List<SeoLang> newReceiptSeoLangs = new List<SeoLang>();
            foreach (var item in seoLangs)
            {
                newReceiptSeoLangs.Add(new SeoLang()
                {
                    Title = item.Title,
                    Keys = item.Keys,
                    Desc = item.Desc,
                    SeoId = newReceiptSeo.Id,
                    LangId = item.LangId
                });
            }
            newReceiptSeo.SeoLangs = newReceiptSeoLangs;  
            newReceipt.UniqueId = newReceiptSeo.UniqueId;
            newReceipt.ReceiptSeo = newReceiptSeo;

            foreach (var item in receiptLangs)
            {
                newReceipt.ReceiptLangs.Add(new ReceiptLang()
                {
                    Title = item.Title,
                    Preparation = item.Preparation,
                    Ingredients = item.Ingredients,
                    ReceiptId = newReceipt.Id,
                    LangId = item.LangId
                });
            }            
            
            await _receiptService.CreateReceipt(newReceipt);
            return RedirectToAction("Index", "Receipt");
        }

        [Route("/cms/receipt/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Receipt receiptFromDb = await _receiptService.GetReceiptById(id);
            if (receiptFromDb == null) return NotFound();

            ReceiptUpdateVM receiptUpdateVM = new ReceiptUpdateVM
            {
                ProductValuesLine = receiptFromDb.ProductValues,
                Products = await _productService.GetAllProducts(),
                ReceiptLangs = receiptFromDb.ReceiptLangs.ToList(),
                SeoLangs = receiptFromDb.ReceiptSeo.SeoLangs.ToList(),
                PhotoUrl = receiptFromDb.ReceiptPhotos.FirstOrDefault(x => x.IsMain == true).PhotoUrl,
                CategoryId = receiptFromDb.CategoryId,
                IsActive = receiptFromDb.IsActive,
            };
            receiptUpdateVM.Categories = await _categoyrLangService.GetAllCategoryLangsFor("receipt");

            if(receiptFromDb.ProductValues != null)
            {
                string[] words = receiptFromDb.ProductValues.Split(',');
                receiptUpdateVM.ProductValues = words;
            }            

            foreach (var item in receiptFromDb.ReceiptPhotos.Where(x => x.IsMain == false).ToList())
                receiptUpdateVM.PhotoUrls.Add(item.PhotoUrl);

            return View(receiptUpdateVM);
        }
        [Route("/cms/receipt/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, ReceiptUpdateVM receiptUpdateVM)
        {
            if (id == 0) return BadRequest();
            Receipt receiptFromDb = await _receiptService.GetReceiptById(id);
            Receipt receiptFromVm = receiptFromDb;
            List<ReceiptPhoto> photos = new List<ReceiptPhoto>();

            if(receiptUpdateVM.MainPhotoFile != null)
            {
                if (!_image.IsImageValid(receiptUpdateVM.MainPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(receiptUpdateVM);
                }
                else
                {
                    _image.Delete("files", "receipt", receiptFromVm.ReceiptPhotos.FirstOrDefault(x => x.IsMain == true).PhotoUrl);
                    receiptFromVm.ReceiptPhotos.FirstOrDefault(x => x.IsMain == true).PhotoUrl = await _image.UploadAsync(receiptUpdateVM.MainPhotoFile, "files", "receipt");
                }
            }
            
            Seo seoFromDb = receiptFromVm.ReceiptSeo;
            if (receiptFromVm == null && seoFromDb == null) return NotFound();
            if (!ModelState.IsValid) return View(receiptUpdateVM);

            if(receiptUpdateVM.PhotoFiles != null)
            {
                foreach (var photoFile in receiptUpdateVM.PhotoFiles)
                {
                    if (!_image.IsImageValid(photoFile))
                    {
                        ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                        return View(receiptUpdateVM);
                    }
                }
                foreach (var item in receiptFromVm.ReceiptPhotos.Where(x => x.IsMain == false))
                {
                    await _receiptPhotoService.DeleteReceiptPhoto(item);
                    _image.Delete("files", "receipt", item.PhotoUrl);                        
                }
                foreach (var photoFile in receiptUpdateVM.PhotoFiles)
                {
                    ReceiptPhoto newReceiptPhoto = new ReceiptPhoto
                    {
                        PhotoUrl = await _image.UploadAsync(photoFile, "files", "receipt"),
                        IsMain = false,
                        ReceiptId = receiptFromVm.Id
                    };
                    await _receiptPhotoService.CreateReceiptPhoto(newReceiptPhoto);
                }
            }

            receiptFromVm.ProductValues = receiptUpdateVM.ProductValuesLine;
            receiptFromVm.SlugUrl = UrlSeoHelper.UrlSeo(receiptUpdateVM.ReceiptLangs.FirstOrDefault(x => x.LangId == 1).Title.Trim());
            receiptFromVm.IsActive = receiptUpdateVM.IsActive;
            Category category = await _categoryService.GetCategoryByCategoryLangId(receiptUpdateVM.CategoryId);
            receiptFromVm.Category = category;
            receiptFromVm.CategoryId = category.Id;

            int count = 0;
            foreach (var item in receiptFromVm.ReceiptSeo.SeoLangs)
            {                
                item.Title = receiptUpdateVM.SeoLangs.ElementAt(count).Title;
                item.Keys = receiptUpdateVM.SeoLangs.ElementAt(count).Keys;
                item.Desc = receiptUpdateVM.SeoLangs.ElementAt(count).Desc;
                count++;
            }

            count = 0;
            foreach (var item in receiptFromVm.ReceiptLangs)
            {
                item.Title = receiptUpdateVM.ReceiptLangs.ElementAt(count).Title;
                item.Preparation = receiptUpdateVM.ReceiptLangs.ElementAt(count).Preparation;
                item.Ingredients = receiptUpdateVM.ReceiptLangs.ElementAt(count).Ingredients;
                count++;
            }        

            await _receiptService.UpdateReceipt(receiptFromDb, receiptFromVm);

            return RedirectToAction("Index", "Receipt");
        }

        [Route("/cms/receipt/status-degistir/{id}")]
        [HttpPost]
        public async Task<IActionResult> StatusToggle(int id)
        {
            Receipt receiptFromDb = await _receiptService.GetReceiptById(id);
            receiptFromDb.IsActive = !receiptFromDb.IsActive;
            await _receiptService.UpdateReceipt(receiptFromDb, receiptFromDb);
            return Json(new { status = 1, title = "İşlem Başarılı", message = "Statüsü değiştirildi!" });
        }

        [Route("/cms/receipt/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Receipt receiptFromDb = await _receiptService.GetReceiptById(id);
            await _receiptService.DeleteReceipt(receiptFromDb);
            foreach (var item in receiptFromDb.ReceiptPhotos)
            {
                _image.Delete("files", "receipt", item.PhotoUrl);                       
            }

            return RedirectToAction("Index", "Receipt");
        }   
    }
}

