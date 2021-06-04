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
        public async Task<IActionResult> Create(SeoCreateVM seoCreateVM, List<SeoLang> seoLangs)
        {
            if (!ModelState.IsValid) return View(seoCreateVM);

            Seo newSeo = new Seo
            {
                SlugUrl = UrlSeoHelper.UrlSeo(seoCreateVM.Page.Trim()),
                IsActive = true,
                UniqueId = Guid.NewGuid().ToString().Replace("-", "").GetHashCode(),
                Page = seoCreateVM.Page,
                IsBlog = false,
                IsProduct = false,
                IsReceipt = false
            };         

            List<SeoLang> newProductSeoLangs = new List<SeoLang>();   
            foreach (var item in seoLangs)
            {
                newProductSeoLangs.Add(new SeoLang()
                {
                    Title = item.Title,
                    Keys = item.Keys,
                    Desc = item.Desc,
                    SeoId = newSeo.Id,
                    LangId = item.LangId
                });
            }
            newSeo.SeoLangs = newProductSeoLangs; 
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
                SeoLangs = seoFromDb.SeoLangs.ToList(),
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
            int count = 0;
            foreach (var item in seoFromVm.SeoLangs)
            {                
                item.Title = seoUpdateVM.SeoLangs.ElementAt(count).Title;
                item.Keys = seoUpdateVM.SeoLangs.ElementAt(count).Keys;
                item.Desc = seoUpdateVM.SeoLangs.ElementAt(count).Desc;
                count++;
            }
            
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
