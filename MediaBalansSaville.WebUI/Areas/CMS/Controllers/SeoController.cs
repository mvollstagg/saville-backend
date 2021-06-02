using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class SeoController : Controller
    {
        private readonly ISeoService _seoService;
        private readonly ILangService _langService;

        public SeoController(ISeoService seoService,
                            ILangService langService)
        {
            this._seoService = seoService;
            this._langService = langService;
        }

        [Route("/cms/seo")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _seoService.GetAllSeos());
        }

        [Route("/cms/seo/yarat")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/cms/seo/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SeoCreateVM seoCreateVM)
        {
            if (!ModelState.IsValid) return View(seoCreateVM);

            Lang azLang = await _langService.GetLangWithCode("az");
            Lang ruLang = await _langService.GetLangWithCode("ru");
            Lang enLang = await _langService.GetLangWithCode("en");

            if (azLang == null && ruLang == null && enLang == null)
            {
                ModelState.AddModelError("", "Öncə məlumat bazasına dillər əlavə edilməlidir !");
                return View(seoCreateVM);
            }

            Seo newSeo = new Seo
            {
                SlugUrl = UrlSeoHelper.UrlSeo(seoCreateVM.TitleAZ.Trim()),
                IsActive = true,
                UniqueId = Guid.NewGuid().ToString().Replace("-", "").GetHashCode(),
                Page = seoCreateVM.Page,
                IsBlog = false,
                IsProduct = false,
                IsReceipt = false
            };            
            List<SeoLang> seoLangs = new List<SeoLang>();
            SeoLang newSeoLangAZ = new SeoLang
            {
                SeoId = newSeo.Id,
                Title = seoCreateVM.TitleAZ,
                Keys = seoCreateVM.KeysAZ,
                Desc = seoCreateVM.DescAZ,
                LangId = azLang.Id       
            };
            SeoLang newSeoLangRU = new SeoLang
            {
                SeoId = newSeo.Id,
                Title = seoCreateVM.TitleRU,
                Keys = seoCreateVM.KeysRU,
                Desc = seoCreateVM.DescRU,
                LangId = ruLang.Id          
            };
            SeoLang newSeoLangEN = new SeoLang
            {
                SeoId = newSeo.Id,
                Title = seoCreateVM.TitleEN,
                Keys = seoCreateVM.KeysEN,
                Desc = seoCreateVM.KeysEN,
                LangId = enLang.Id            
            };
            seoLangs.Add(newSeoLangAZ);
            seoLangs.Add(newSeoLangRU);
            seoLangs.Add(newSeoLangEN);
            newSeo.SeoLangs = seoLangs;
            await _seoService.CreateSeo(newSeo);
            return RedirectToAction("Index", "Seo");
        }

        [Route("/cms/seo/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Seo seoFromDb = await _seoService.GetSeoById(id);
            if (seoFromDb == null) return NotFound();

            SeoCreateVM seoUpdateVM = new SeoCreateVM
            {
                TitleAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Title,
                KeysAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Keys,
                DescAZ = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Desc,
                TitleRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Title,
                KeysRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Keys,
                DescRU = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Desc,
                TitleEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Title,
                KeysEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Keys,
                DescEN = seoFromDb.SeoLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Desc,
                Page = seoFromDb.Page          
            };
            return View(seoUpdateVM);
        }

        [Route("/cms/seo/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SeoCreateVM seoUpdateVM)
        {
            if (id == 0) return BadRequest();
            Seo seoFromDb = await _seoService.GetSeoById(id);
            Seo seoFromVm = seoFromDb;
            if (seoFromDb == null) return NotFound();
            if (!ModelState.IsValid) return View(seoUpdateVM);

            seoFromVm.Page = seoUpdateVM.Page;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "az").Title = seoUpdateVM.TitleAZ;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "az").Keys = seoUpdateVM.KeysAZ;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "az").Desc = seoUpdateVM.DescAZ;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "ru").Title = seoUpdateVM.TitleRU;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "ru").Keys = seoUpdateVM.KeysRU;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "ru").Desc = seoUpdateVM.DescRU;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "en").Title = seoUpdateVM.TitleEN;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "en").Keys = seoUpdateVM.KeysEN;
            seoFromVm.SeoLangs.FirstOrDefault(x =>x.Lang.Code == "en").Desc = seoUpdateVM.DescEN;
            
            await _seoService.UpdateSeo(seoFromDb, seoFromVm);
            return RedirectToAction("Index", "Seo");
        }

        [Route("/cms/seo/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Seo seoFromDb = await _seoService.GetSeoById(id);
            await _seoService.DeleteSeo(seoFromDb);

            return RedirectToAction("Index", "Seo");
        }
    }
}
