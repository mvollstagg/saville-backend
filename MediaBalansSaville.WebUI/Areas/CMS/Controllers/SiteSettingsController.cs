
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
                
                return View(SiteSettingsUpdateVM);
            }
            else
            {
                SiteSettingsVM settingsVM = new SiteSettingsVM
                {
                    FacebookURL = SiteSettingsFromDb.FacebookURL,
                    InstagramURL = SiteSettingsFromDb.InstagramURL,
                    TwitterURL = SiteSettingsFromDb.TwitterURL,
                    AdVideoURL = SiteSettingsFromDb.AdVideoURL,
                    PhoneNumber = SiteSettingsFromDb.PhoneNumber,
                    Email = SiteSettingsFromDb.Email,
                    AddressAZ = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").Adress,
                    AddressRU = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").Adress,
                    AddressEN = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").Adress,
                    AboutTitleAZ = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").AboutTitle,
                    AboutTitleRU = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").AboutTitle,
                    AboutTitleEN = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").AboutTitle,
                    AboutDetailAZ = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").AboutDetail,
                    AboutDetailRU = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").AboutDetail,
                    AboutDetailEN = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").AboutDetail,
                    AdDetailAZ = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").AdDetail,
                    AdDetailRU = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").AdDetail,
                    AdDetailEN = SiteSettingsFromDb.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").AdDetail,
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
            
            
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Adress = SiteSettingsUpdateVM.AddressAZ;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Adress = SiteSettingsUpdateVM.AddressRU;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Adress = SiteSettingsUpdateVM.AddressEN;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").AboutTitle = SiteSettingsUpdateVM.AboutTitleAZ;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").AboutTitle = SiteSettingsUpdateVM.AboutTitleRU;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").AboutTitle = SiteSettingsUpdateVM.AboutTitleEN;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").AboutDetail = SiteSettingsUpdateVM.AboutDetailAZ;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").AboutDetail = SiteSettingsUpdateVM.AboutDetailRU;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").AboutDetail = SiteSettingsUpdateVM.AboutDetailEN;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").AdDetail = SiteSettingsUpdateVM.AdDetailAZ;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").AdDetail = SiteSettingsUpdateVM.AdDetailRU;
            SiteSettingsFromVm.SiteSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").AdDetail = SiteSettingsUpdateVM.AdDetailEN;

            await _SiteSettingsService.UpdateSiteSettings(SiteSettingsFromDb, SiteSettingsFromVm);
            return RedirectToAction("Index", "SiteSettings");             
        }
    }
}
