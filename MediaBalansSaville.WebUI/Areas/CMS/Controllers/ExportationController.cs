
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
    public class ExportationController : Controller
    {
        private readonly IExportationService _exportationService;
        private readonly ILangService _langService;

        public ExportationController(IExportationService exportationService,
                                    ILangService langService)
        {
            this._langService = langService;
            this._exportationService = exportationService;
        }
        
        [Route("/cms/ixrac")]
        public async Task<IActionResult> Index()
        {            
            Exportation exportationFromDb = await _exportationService.GetExportations();
            ExportationVM exportationUpdateVM = new ExportationVM();
            if (exportationFromDb == null)
            {
                Lang azLang = await _langService.GetLangWithCode("az");
                Lang ruLang = await _langService.GetLangWithCode("ru");
                Lang enLang = await _langService.GetLangWithCode("en");

                exportationFromDb = new Exportation();
                
                ExportationLang newExportationLangAZ = new ExportationLang
                {
                    ExportationId = exportationFromDb.Id,
                    LangId = azLang.Id                    
                };
                ExportationLang newExportationLangRU = new ExportationLang
                {
                    ExportationId = exportationFromDb.Id,
                    LangId = ruLang.Id                    
                };
                ExportationLang newExportationLangEN = new ExportationLang
                {
                    ExportationId = exportationFromDb.Id,
                    LangId = enLang.Id                    
                };
                exportationFromDb.ExportationLangs.Add(newExportationLangAZ);
                exportationFromDb.ExportationLangs.Add(newExportationLangRU);
                exportationFromDb.ExportationLangs.Add(newExportationLangEN);
                await _exportationService.CreateExportations(exportationFromDb);
                
                return RedirectToAction("Index", "Exportation");
            }
            else
            {
                ExportationVM settingsVM = new ExportationVM
                {
                    DetailsAZ = exportationFromDb.ExportationLangs.FirstOrDefault(x => x.Lang.Code == "az").Details,
                    DetailsRU = exportationFromDb.ExportationLangs.FirstOrDefault(x => x.Lang.Code == "ru").Details,
                    DetailsEN = exportationFromDb.ExportationLangs.FirstOrDefault(x => x.Lang.Code == "en").Details,
                    Countries = await _exportationService.GetAllCountries()
                };
                
                return View(settingsVM);
            } 
        }

        [Route("/cms/ixrac/duzeliset")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(ExportationVM ExportationUpdateVM)
        {            
            Exportation exportationFromDb = await _exportationService.GetExportations();
            Exportation exportationFromVm = exportationFromDb;
            if (!ModelState.IsValid) return View(ExportationUpdateVM);            
            
            exportationFromVm.ExportationLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Details = ExportationUpdateVM.DetailsAZ;
            exportationFromVm.ExportationLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Details = ExportationUpdateVM.DetailsRU;
            exportationFromVm.ExportationLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Details = ExportationUpdateVM.DetailsEN;

            await _exportationService.UpdateExportations(exportationFromDb, exportationFromVm);
            return RedirectToAction("Index", "Exportation");             
        }

        #region  Countries
        [Route("/cms/ulkeler/yarat")]
        public IActionResult CreateCountry()
        {
            return View();
        }

        [Route("/cms/ulkeler/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCountry(CountryCreateVM countryCreateVM)
        {
            if (!ModelState.IsValid) return View(countryCreateVM);
            Exportation exportationFromDb = await _exportationService.GetExportations();

            ExportationCountry newCountry = new ExportationCountry
            {
                Code = countryCreateVM.Code,
                Name = countryCreateVM.Name
            };

            await _exportationService.CreateCountry(newCountry);

            return RedirectToAction("Index", "Exportation");
        }

        [Route("/cms/ulkeler/duzeliset/{id}")]
        public async Task<IActionResult> UpdateCountry(int id)
        {
            if (id == 0) return BadRequest();
            ExportationCountry exportationFromDb = await _exportationService.GetCountryById(id);
            if (exportationFromDb == null) return NotFound();

            CountryUpdateVM countryUpdateVM = new CountryUpdateVM
            {                
                Code = exportationFromDb.Code,
                Name = exportationFromDb.Name
            };
            return View(countryUpdateVM);
        }

        [Route("/cms/ulkeler/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCountry(int id, CountryUpdateVM countryUpdateVM)
        {
            if (id == 0) return BadRequest();
            ExportationCountry exportationFromDb = await _exportationService.GetCountryById(id);
            ExportationCountry certificateFromVm = exportationFromDb;
            if (exportationFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(countryUpdateVM);
            certificateFromVm.Code = countryUpdateVM.Code;
            certificateFromVm.Name = countryUpdateVM.Name;

            await _exportationService.UpdateCountry(exportationFromDb, certificateFromVm);

            return RedirectToAction("Index", "Exportation");            
        }

        [Route("/cms/ulkeler/kaldir/{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id == 0) return BadRequest();
            ExportationCountry exportationFromDb = await _exportationService.GetCountryById(id);
            await _exportationService.DeleteCountry(exportationFromDb);

            return RedirectToAction("Index", "Exportation");
        }

        [Route("/cms/ulkeler/status-degistir")]
        [HttpPost]
        public async Task<IActionResult> StatusToggle(int id)
        {
            ExportationCountry exportationFromDb = await _exportationService.GetCountryById(id);
            exportationFromDb.IsActive = !exportationFromDb.IsActive;
            await _exportationService.UpdateCountry(exportationFromDb, exportationFromDb);
            return Json(new { status = exportationFromDb.IsActive, title = "İşlem Başarılı", message = "Statüsü değiştirildi!" });
        }
        #endregion   
    }
}
