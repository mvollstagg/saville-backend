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
    public class PomegranateController : Controller
    {
        private readonly IPomegranateService _pomegranateService;
        private readonly ILogger<AboutController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PomegranateController(IHttpContextAccessor httpContextAccessor,
                                IPomegranateService pomegranateService,
                                ILogger<AboutController> logger)
        {
            this._httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            _pomegranateService = pomegranateService;
            this._logger = logger;
        }
        [Route("/{_lang}/narinfaydalari")]
        public async Task<IActionResult> Index(string _lang = "en")
        {  
            try
            {           
                ViewBag.Lang = _lang;                
                MainHelper.SetLang(_httpContextAccessor, _lang);
                PomegranateSettings pomegranateSettings = await _pomegranateService.GetPomegranateSettings();                

                return View(pomegranateSettings);              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }  
        }
    }
}
