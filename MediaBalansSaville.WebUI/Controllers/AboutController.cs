using MediaBalansSaville.Entities;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Models;
using System;
using System.Threading.Tasks;
using MediaBalansSaville.Core.Services;
using Microsoft.Extensions.Logging;

namespace MediaBalansSaville.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutSettingservice _aboutSettingservice;
        private readonly ILogger<AboutController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AboutController(IHttpContextAccessor httpContextAccessor,
                                IAboutSettingservice aboutSettingservice,
                                ILogger<AboutController> logger)
        {
            this._httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            this._aboutSettingservice = aboutSettingservice;
            this._logger = logger;
        }
        [Route("/{_lang}/haqqimizda")]
        public async Task<IActionResult> Index(string _lang = "az")
        {  
            try
            {           
                ViewBag.Lang = _lang;                
                MainHelper.SetLang(_httpContextAccessor, _lang);
                AboutSettings aboutSettingsFromDb = await _aboutSettingservice.GetAboutSettings();
                AboutSettingsVM settingsVM = new AboutSettingsVM()
                {
                    AboutSettingsLangs = aboutSettingsFromDb.AboutSettingsLangs,
                    Certificates = aboutSettingsFromDb.AboutSettingsCertificates,
                    AboutSettingsItems = aboutSettingsFromDb.AboutSettingsItems,
                };

                return View(settingsVM);              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }  
        }
    }
}
