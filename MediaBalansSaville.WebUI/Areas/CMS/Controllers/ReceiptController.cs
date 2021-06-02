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
        private readonly ICategoryLangService _categoyrLangService;
        private readonly IReceiptService _receiptService;
        private readonly IReceiptPhotoService _receiptPhotoService;
        private readonly IImage _image;

        public ReceiptController(ILangService langService, 
                                ICategoryService categoryService,
                                IImage image,
                                IReceiptService receiptService,
                                ICategoryLangService categoyrLangService,
                                IReceiptPhotoService receiptPhotoService)
        {
            this._categoryService = categoryService;
            this._langService = langService;
            this._image = image;
            this._receiptService = receiptService;
            this._categoyrLangService = categoyrLangService;
            this._receiptPhotoService = receiptPhotoService;
        }
        [Route("/cms/Receipt")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _receiptService.GetAllReceipts());
        }

        [Route("/cms/Receipt/yarat")]
        public async Task<IActionResult> Create()
        {
            ReceiptCreateVM receiptCreateVM = new ReceiptCreateVM
            {
                Categories = await _categoyrLangService.GetAllCategoryLangsFor("receipt")                
            };
            return View(receiptCreateVM);
        }
        [Route("/cms/Receipt/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReceiptCreateVM receiptCreateVM)
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

            Lang azLang = await _langService.GetLangWithCode("az");
            Lang ruLang = await _langService.GetLangWithCode("ru");
            Lang enLang = await _langService.GetLangWithCode("en");

            if (azLang == null && ruLang == null && enLang == null)
            {
                ModelState.AddModelError("", "Öncə məlumat bazasına dillər əlavə edilməlidir !");
                return View(receiptCreateVM);
            }            
            Category category = await _categoryService.GetCategoryByCategoryLangId(receiptCreateVM.CategoryId);
            Receipt newReceipt = new Receipt
            {         
                CategoryId = category.Id,
                Category = category, 
                IsActive = receiptCreateVM.IsActive                
            };
            newReceipt.SlugUrl = UrlSeoHelper.UrlSeo(receiptCreateVM.TitleAZ.Trim());
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
            
            ReceiptLang newReceiptLangAZ = new ReceiptLang
            {                               
                ReceiptId = newReceipt.Id,
                LangId = azLang.Id
            };

            ReceiptLang newReceiptLangRU = new ReceiptLang
            {             
                ReceiptId = newReceipt.Id,
                LangId = ruLang.Id
            };

            ReceiptLang newReceiptLangEN = new ReceiptLang
            {            
                ReceiptId = newReceipt.Id,
                LangId = enLang.Id
            };
           
            newReceiptLangAZ.Title = receiptCreateVM.TitleAZ.Trim();
            newReceiptLangRU.Title = receiptCreateVM.TitleRU.Trim();
            newReceiptLangEN.Title = receiptCreateVM.TitleEN.Trim();
            newReceiptLangAZ.Preparation = receiptCreateVM.PreparationAZ.Trim();
            newReceiptLangRU.Preparation = receiptCreateVM.PreparationRU.Trim();
            newReceiptLangEN.Preparation = receiptCreateVM.PreparationEN.Trim();
            newReceiptLangAZ.Ingredients = receiptCreateVM.IngredientsAZ.Trim();
            newReceiptLangRU.Ingredients = receiptCreateVM.IngredientsRU.Trim();
            newReceiptLangEN.Ingredients = receiptCreateVM.IngredientsRU.Trim();
            Seo newReceiptSeo = new Seo
            {
                SlugUrl = UrlSeoHelper.UrlSeo(receiptCreateVM.TitleAZ.Trim()),
                IsActive = true,
                UniqueId = Guid.NewGuid().ToString().Replace("-", "").GetHashCode(),
                Page = receiptCreateVM.TitleAZ.Trim(),
                IsReceipt = true
            };
            List<SeoLang> seoLangs = new List<SeoLang>();
            SeoLang newSeoLangAZ = new SeoLang
            {
                SeoId = newReceiptSeo.Id,
                Title = receiptCreateVM.SeoTitleAZ,
                Keys = receiptCreateVM.SeoKeysAZ,
                Desc = receiptCreateVM.SeoDescAZ,
                LangId = azLang.Id           
            };
            SeoLang newSeoLangRU = new SeoLang
            {
                SeoId = newReceiptSeo.Id,
                Title = receiptCreateVM.SeoTitleRU,
                Keys = receiptCreateVM.SeoKeysRU,
                Desc = receiptCreateVM.SeoDescRU,
                LangId = ruLang.Id             
            };
            SeoLang newSeoLangEN = new SeoLang
            {
                SeoId = newReceiptSeo.Id,
                Title = receiptCreateVM.SeoTitleEN,
                Keys = receiptCreateVM.SeoKeysEN,
                Desc = receiptCreateVM.SeoDescEN,
                LangId = enLang.Id        
            };
            newReceipt.UniqueId = newReceiptSeo.UniqueId;
            seoLangs.Add(newSeoLangAZ);
            seoLangs.Add(newSeoLangRU);
            seoLangs.Add(newSeoLangEN);
            newReceiptSeo.SeoLangs = seoLangs;                
            newReceipt.ReceiptSeo = newReceiptSeo;
            
            newReceipt.ReceiptLangs.Add(newReceiptLangAZ);
            newReceipt.ReceiptLangs.Add(newReceiptLangRU);
            newReceipt.ReceiptLangs.Add(newReceiptLangEN);
            
            await _receiptService.CreateReceipt(newReceipt);
            return RedirectToAction("Index", "Receipt");
        }

        [Route("/cms/receipt/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Receipt receiptFromDb = await _receiptService.GetReceiptById(id);
            ReceiptUpdateVM receiptUpdateVM = new ReceiptUpdateVM();
            
            Seo seoFromDb = receiptFromDb.ReceiptSeo;
            if (receiptFromDb == null && seoFromDb == null) return NotFound();

            receiptUpdateVM = new ReceiptUpdateVM
            {
                TitleAZ = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Title,
                TitleRU = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Title,
                TitleEN = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Title,
                PreparationAZ = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Preparation,
                PreparationRU = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Preparation,
                PreparationEN = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Preparation,
                IngredientsAZ = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Ingredients,
                IngredientsRU = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Ingredients,
                IngredientsEN = receiptFromDb.ReceiptLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Ingredients,
                SeoTitleAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Title,
                SeoKeysAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Keys,
                SeoDescAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Desc,
                SeoTitleRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Title,
                SeoKeysRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Keys,
                SeoDescRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Desc,
                SeoTitleEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Title,
                SeoKeysEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Keys,
                SeoDescEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Desc,
                PhotoUrl = receiptFromDb.ReceiptPhotos.FirstOrDefault(x => x.IsMain == true).PhotoUrl,
                CategoryId = receiptFromDb.CategoryId,
                IsActive = receiptFromDb.IsActive,
            };
            receiptUpdateVM.Categories = await _categoyrLangService.GetAllCategoryLangsFor("receipt");

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
            }
            if (receiptUpdateVM.MainPhotoFile != null)
            {
                _image.Delete("files", "receipt", receiptFromVm.ReceiptPhotos.FirstOrDefault(x => x.IsMain == true).PhotoUrl);

                receiptFromVm.ReceiptPhotos.FirstOrDefault(x => x.IsMain == true).PhotoUrl = await _image.UploadAsync(receiptUpdateVM.MainPhotoFile, "files", "receipt");                
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
            }

            receiptFromVm.SlugUrl = UrlSeoHelper.UrlSeo(receiptUpdateVM.TitleAZ.Trim());
            receiptFromVm.IsActive = receiptUpdateVM.IsActive;
            Category category = await _categoryService.GetCategoryByCategoryLangId(receiptUpdateVM.CategoryId);
            receiptFromVm.Category = category;
            receiptFromVm.CategoryId = category.Id;

            if (receiptUpdateVM.PhotoFiles != null)
            {
                foreach (var item in receiptFromVm.ReceiptPhotos.Where(x => x.IsMain == false))
                {
                    await _receiptPhotoService.DeleteReceiptPhoto(item);
                    _image.Delete("files", "receipt", item.PhotoUrl);                        
                }

                for (int i = 0; i < receiptUpdateVM.PhotoFiles.Count(); i++)
                {
                    var item = receiptUpdateVM.PhotoFiles.ElementAtOrDefault(i);

                    ReceiptPhoto newReceiptPhoto = new ReceiptPhoto
                    {
                        PhotoUrl = await _image.UploadAsync(item, "files", "receipt"),
                        IsMain = false,
                        ReceiptId = receiptFromVm.Id
                    };
                    await _receiptPhotoService.CreateReceiptPhoto(newReceiptPhoto);
                }
            }

            SeoLang azReceiptSeoFromDb = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az");  
            SeoLang ruReceiptSeoFromDb = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru"); 
            SeoLang enReceiptSeoFromDb = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en");   
            azReceiptSeoFromDb.Title = receiptUpdateVM.SeoTitleAZ;
            azReceiptSeoFromDb.Keys = receiptUpdateVM.SeoKeysAZ;
            azReceiptSeoFromDb.Desc = receiptUpdateVM.SeoDescAZ;
            ruReceiptSeoFromDb.Title = receiptUpdateVM.SeoTitleRU;
            ruReceiptSeoFromDb.Keys = receiptUpdateVM.SeoKeysRU;
            ruReceiptSeoFromDb.Desc = receiptUpdateVM.SeoDescRU;
            enReceiptSeoFromDb.Title = receiptUpdateVM.SeoTitleEN;
            enReceiptSeoFromDb.Keys = receiptUpdateVM.SeoKeysEN;
            enReceiptSeoFromDb.Desc = receiptUpdateVM.SeoDescEN;

            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "az").Title = receiptUpdateVM.TitleAZ.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "az").Preparation = receiptUpdateVM.PreparationAZ.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "az").Ingredients = receiptUpdateVM.IngredientsAZ.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "ru").Title = receiptUpdateVM.TitleRU.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "ru").Preparation = receiptUpdateVM.PreparationRU.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "ru").Ingredients = receiptUpdateVM.IngredientsRU.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "en").Title = receiptUpdateVM.TitleEN.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "en").Preparation = receiptUpdateVM.PreparationEN.Trim();
            receiptFromVm.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == "en").Ingredients = receiptUpdateVM.IngredientsEN.Trim();
        

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

