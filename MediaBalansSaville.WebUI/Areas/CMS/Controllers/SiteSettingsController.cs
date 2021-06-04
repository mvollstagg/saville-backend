
using System.Linq;
using System.Threading.Tasks;
using MediaBalansSaville.Core.Services;
using MediaBalansSaville.Entities;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{

    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class SiteSettingsController : Controller
    {
        private readonly ISiteSettingsService _SiteSettingsService;
        private readonly ILangService _langService;

        public SiteSettingsController(ISiteSettingsService SiteSettingsService,
                                    ILangService langService)
        {
            this._langService = langService;
            this._SiteSettingsService = SiteSettingsService;
        }
        
        [Route("/cms/saytparametrleri")]
        public async Task<IActionResult> Index()
        {            
            SiteSettings SiteSettingsFromDb = await _SiteSettingsService.GetSiteSettings();
            SiteSettingsVM SiteSettingsUpdateVM = new SiteSettingsVM();
            if (SiteSettingsFromDb == null)
            {
                Lang azLang = await _langService.GetLangWithCode("az");
                Lang ruLang = await _langService.GetLangWithCode("ru");
                Lang enLang = await _langService.GetLangWithCode("en");

                SiteSettingsFromDb = new SiteSettings();
                
                SiteSettingsLang newSiteSettingsLangAZ = new SiteSettingsLang
                {
                    SiteSettingsId = SiteSettingsFromDb.Id,
                    LangId = azLang.Id                    
                };
                SiteSettingsLang newSiteSettingsLangRU = new SiteSettingsLang
                {
                    SiteSettingsId = SiteSettingsFromDb.Id,
                    LangId = ruLang.Id                    
                };
                SiteSettingsLang newSiteSettingsLangEN = new SiteSettingsLang
                {
                    SiteSettingsId = SiteSettingsFromDb.Id,
                    LangId = enLang.Id                    
                };
                SiteSettingsFromDb.SiteSettingsLangs.Add(newSiteSettingsLangAZ);
                SiteSettingsFromDb.SiteSettingsLangs.Add(newSiteSettingsLangRU);
                SiteSettingsFromDb.SiteSettingsLangs.Add(newSiteSettingsLangEN);
                await _SiteSettingsService.CreateSiteSettings(SiteSettingsFromDb);
                
                return RedirectToAction("Index", "SiteSettings");
            }
            else
            {
                SiteSettingsVM settingsVM = new SiteSettingsVM
                {
                    SiteSettingsLangs = SiteSettingsFromDb.SiteSettingsLangs.ToList(),
                    FacebookURL = SiteSettingsFromDb.FacebookURL,
                    InstagramURL = SiteSettingsFromDb.InstagramURL,
                    TwitterURL = SiteSettingsFromDb.TwitterURL,
                    AdVideoURL = SiteSettingsFromDb.AdVideoURL,
                    PhoneNumber = SiteSettingsFromDb.PhoneNumber,
                    Email = SiteSettingsFromDb.Email,                    
                    GoogleAnalyticsCode = SiteSettingsFromDb.GoogleAnalyticsCode,
                    FacebookPixel = SiteSettingsFromDb.FacebookPixel,
                };
                
                return View(settingsVM);
            } 
        }

        [Route("/cms/saytparametrleri/duzeliset")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SiteSettingsVM SiteSettingsUpdateVM)
        {            
            SiteSettings SiteSettingsFromDb = await _SiteSettingsService.GetSiteSettings();
            SiteSettings SiteSettingsFromVm = SiteSettingsFromDb;
            if (!ModelState.IsValid) return View(SiteSettingsUpdateVM);
            
            SiteSettingsFromVm.FacebookURL = SiteSettingsUpdateVM.FacebookURL;
            SiteSettingsFromVm.InstagramURL = SiteSettingsUpdateVM.InstagramURL;
            SiteSettingsFromVm.TwitterURL = SiteSettingsUpdateVM.TwitterURL;
            SiteSettingsFromVm.AdVideoURL = SiteSettingsUpdateVM.AdVideoURL;
            SiteSettingsFromVm.PhoneNumber = SiteSettingsUpdateVM.PhoneNumber;
            SiteSettingsFromVm.Email = SiteSettingsUpdateVM.Email;
            SiteSettingsFromVm.GoogleAnalyticsCode = SiteSettingsUpdateVM.GoogleAnalyticsCode;
            SiteSettingsFromVm.FacebookPixel = SiteSettingsUpdateVM.FacebookPixel;
            
            int count = 0;
            foreach (var item in SiteSettingsFromVm.SiteSettingsLangs)
            {                
                item.Adress = SiteSettingsUpdateVM.SiteSettingsLangs.ElementAt(count).Adress;
                item.AboutTitle = SiteSettingsUpdateVM.SiteSettingsLangs.ElementAt(count).AboutTitle;
                item.AboutDetail = SiteSettingsUpdateVM.SiteSettingsLangs.ElementAt(count).AboutDetail;
                item.AdDetail = SiteSettingsUpdateVM.SiteSettingsLangs.ElementAt(count).AdDetail;
                count++;
            }

            await _SiteSettingsService.UpdateSiteSettings(SiteSettingsFromDb, SiteSettingsFromVm);
            return RedirectToAction("Index", "SiteSettings");             
        }
    }
}
