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
    public class FAQController : Controller
    {
        private readonly IFAQService _FAQService;
        private readonly ILogger<AboutController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FAQController(IHttpContextAccessor httpContextAccessor,
                                IExportationService exportationService,
                                ILogger<AboutController> logger,
                                IFAQService FAQService)
        {
            this._httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            _FAQService = FAQService;
            this._logger = logger;
        }
        [Route("/{_lang}/faq")]
        public async Task<IActionResult> Index(string _lang = "en")
        {  
            try
            {           
                ViewBag.Lang = _lang;                
                MainHelper.SetLang(_httpContextAccessor, _lang);
                
                         

                return View(await _FAQService.GetAllFAQs());              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }  
        }
    }
}
