
using System.Linq;
using System.Threading.Tasks;
using MediaBalansSaville.Core.Services;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Services.Utilities;
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
        private readonly IImage _image;

        public SiteSettingsController(ISiteSettingsService SiteSettingsService,
                                    ILangService langService,
                                    IImage image)
        {
            this._langService = langService;
            this._SiteSettingsService = SiteSettingsService;
            _image = image;
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
                SiteSettingsFromDb.VideoCoverUrl = "CoverPhotoUrl";
                SiteSettingsFromDb.LogoUrl = "LogoPhotoUrl";
                SiteSettingsFromDb.SliderUrl = "SliderPhotoUrl";
                
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
                    LogoUrl = SiteSettingsFromDb.LogoUrl,
                    SliderUrl = SiteSettingsFromDb.SliderUrl,
                    VideoPhotoUrl = SiteSettingsFromDb.VideoCoverUrl,
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
            
            if(SiteSettingsUpdateVM.LogoPhotoFile != null)
            {
                if (!_image.IsImageValid(SiteSettingsUpdateVM.LogoPhotoFile))
                {
                    ModelState.AddModelError("", "Dosya .jpg/.jpeg/.png formatında ve maksimum 3MB boyutunda olmalıdır!");
                    return View(SiteSettingsUpdateVM);
                }
                else
                {
                    _image.Delete("files", "sitesettings", SiteSettingsFromVm.LogoUrl);
                    SiteSettingsFromVm.LogoUrl = await _image.UploadAsync(SiteSettingsUpdateVM.LogoPhotoFile, "files", "sitesettings"); 
                }
            }
            if(SiteSettingsUpdateVM.SliderPhotoFile != null)
            {
                if (!_image.IsImageValid(SiteSettingsUpdateVM.SliderPhotoFile))
                {
                    ModelState.AddModelError("", "Dosya .jpg/.jpeg/.png formatında ve maksimum 3MB boyutunda olmalıdır!");
                    return View(SiteSettingsUpdateVM);
                }
                else
                {
                    _image.Delete("files", "sitesettings", SiteSettingsFromVm.SliderUrl);
                    SiteSettingsFromVm.SliderUrl = await _image.UploadAsync(SiteSettingsUpdateVM.SliderPhotoFile, "files", "sitesettings"); 
                }
            }
            if(SiteSettingsUpdateVM.VideoPhotoFile != null)
            {
                if (!_image.IsImageValid(SiteSettingsUpdateVM.VideoPhotoFile))
                {
                    ModelState.AddModelError("", "Dosya .jpg/.jpeg/.png formatında ve maksimum 3MB boyutunda olmalıdır!");
                    return View(SiteSettingsUpdateVM);
                }
                else
                {
                    _image.Delete("files", "sitesettings", SiteSettingsFromVm.VideoCoverUrl);
                    SiteSettingsFromVm.VideoCoverUrl = await _image.UploadAsync(SiteSettingsUpdateVM.VideoPhotoFile, "files", "sitesettings"); 
                }
            }

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
                item.SliderTitle = SiteSettingsUpdateVM.SiteSettingsLangs.ElementAt(count).SliderTitle;
                item.SliderDetails = SiteSettingsUpdateVM.SiteSettingsLangs.ElementAt(count).SliderDetails;
                count++;
            }

            await _SiteSettingsService.UpdateSiteSettings(SiteSettingsFromDb, SiteSettingsFromVm);
            return RedirectToAction("Index", "SiteSettings");             
        }
    }
}
