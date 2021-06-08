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
    public class ExportationController : Controller
    {
        private readonly IExportationService _exportationService;
        private readonly ILogger<AboutController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExportationController(IHttpContextAccessor httpContextAccessor,
                                IExportationService exportationService,
                                ILogger<AboutController> logger)
        {
            this._httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            _exportationService = exportationService;
            this._logger = logger;
        }
        [Route("/{_lang}/ixracat")]
        public async Task<IActionResult> Index(string _lang = "az")
        {  
            try
            {           
                ViewBag.Lang = _lang;                
                MainHelper.SetLang(_httpContextAccessor, _lang);
                var countries = await _exportationService.GetAllCountries();
                ExportationVM exportationVM = new ExportationVM()
                {
                    Exportation = await _exportationService.GetExportations(),
                    Countries = countries.Where(x => x.IsActive == true)
                };             

                return View(exportationVM);              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }  
        }
    }
}
