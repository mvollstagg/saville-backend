
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
    public class PomegranateController : Controller
    {
        private readonly IPomegranateService _pomegranateService;
        private readonly ILangService _langService;

        public PomegranateController(IPomegranateService pomegranateService,
                                    ILangService langService)
        {
            this._langService = langService;
            this._pomegranateService = pomegranateService;
        }
        
        [Route("/cms/narinfaydalari")]
        public async Task<IActionResult> Index()
        {            
            PomegranateSettings PomegranateSettingsFromDb = await _pomegranateService.GetPomegranateSettings();
            PomegranateVM PomegranateSettingsUpdateVM = new PomegranateVM();
            if (PomegranateSettingsFromDb == null)
            {
                Lang azLang = await _langService.GetLangWithCode("az");
                Lang ruLang = await _langService.GetLangWithCode("ru");
                Lang enLang = await _langService.GetLangWithCode("en");

                PomegranateSettingsFromDb = new PomegranateSettings();
                
                PomegranateSettingsLang newPomegranateSettingsLangAZ = new PomegranateSettingsLang
                {
                    PomegranateSettingsId = PomegranateSettingsFromDb.Id,
                    LangId = azLang.Id                    
                };
                PomegranateSettingsLang newPomegranateSettingsLangRU = new PomegranateSettingsLang
                {
                    PomegranateSettingsId = PomegranateSettingsFromDb.Id,
                    LangId = ruLang.Id                    
                };
                PomegranateSettingsLang newPomegranateSettingsLangEN = new PomegranateSettingsLang
                {
                    PomegranateSettingsId = PomegranateSettingsFromDb.Id,
                    LangId = enLang.Id                    
                };
                PomegranateSettingsFromDb.PomegranateSettingsLangs.Add(newPomegranateSettingsLangAZ);
                PomegranateSettingsFromDb.PomegranateSettingsLangs.Add(newPomegranateSettingsLangRU);
                PomegranateSettingsFromDb.PomegranateSettingsLangs.Add(newPomegranateSettingsLangEN);
                await _pomegranateService.CreatePomegranateSettings(PomegranateSettingsFromDb);
                
                return RedirectToAction("Index", "Pomegranate");  
            }
            else
            {
                PomegranateVM settingsVM = new PomegranateVM
                {
                    Langs = PomegranateSettingsFromDb.PomegranateSettingsLangs.ToList(),
                };
                
                return View(settingsVM);
            } 
        }

        [Route("/cms/narinfaydalari/duzeliset")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(PomegranateVM PomegranateSettingsUpdateVM)
        {            
            PomegranateSettings PomegranateSettingsFromDb = await _pomegranateService.GetPomegranateSettings();
            PomegranateSettings PomegranateSettingsFromVm = PomegranateSettingsFromDb;
            if (!ModelState.IsValid) return View(PomegranateSettingsUpdateVM);
            
            
            int count = 0;
            foreach (var item in PomegranateSettingsFromVm.PomegranateSettingsLangs)
            {                
                item.MainTitle = PomegranateSettingsUpdateVM.Langs.ElementAt(count).MainTitle;
                item.MainDetails = PomegranateSettingsUpdateVM.Langs.ElementAt(count).MainDetails;
                item.RhythmTitle = PomegranateSettingsUpdateVM.Langs.ElementAt(count).RhythmTitle;
                item.RhythmDetails = PomegranateSettingsUpdateVM.Langs.ElementAt(count).RhythmDetails;
                item.BoostTitle = PomegranateSettingsUpdateVM.Langs.ElementAt(count).BoostTitle;
                item.BoostDetails = PomegranateSettingsUpdateVM.Langs.ElementAt(count).BoostDetails;
                item.HealthInsuranceTitle = PomegranateSettingsUpdateVM.Langs.ElementAt(count).HealthInsuranceTitle;
                item.HealthInsuranceDetails = PomegranateSettingsUpdateVM.Langs.ElementAt(count).HealthInsuranceDetails;
                count++;
            }

            await _pomegranateService.UpdatePomegranateSettings(PomegranateSettingsFromDb, PomegranateSettingsFromVm);
            return RedirectToAction("Index", "Pomegranate");             
        }
    }
}
