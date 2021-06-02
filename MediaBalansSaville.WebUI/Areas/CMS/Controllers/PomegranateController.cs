
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
                
                return View(PomegranateSettingsUpdateVM);
            }
            else
            {
                PomegranateVM settingsVM = new PomegranateVM
                {
                    MainTitleAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").MainTitle,
                    MainTitleRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").MainTitle,
                    MainTitleEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").MainTitle,
                    MainDetailsAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").MainDetails,
                    MainDetailsRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").MainDetails,
                    MainDetailsEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").MainDetails,
                    RhythmTitleAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").RhythmTitle,
                    RhythmTitleRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").RhythmTitle,
                    RhythmTitleEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").RhythmTitle,
                    RhythmDetailsAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").RhythmDetails,
                    RhythmDetailsRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").RhythmDetails,
                    RhythmDetailsEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").RhythmDetails,
                    BoostTitleAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").BoostTitle,
                    BoostTitleRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").BoostTitle,
                    BoostTitleEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").BoostTitle,
                    BoostDetailsAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").BoostDetails,
                    BoostDetailsRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").BoostDetails,
                    BoostDetailsEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").BoostDetails,
                    HealthInsuranceTitleAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").HealthInsuranceTitle,
                    HealthInsuranceTitleRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").HealthInsuranceTitle,
                    HealthInsuranceTitleEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").HealthInsuranceTitle,
                    HealthInsuranceDetailsAZ = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "az").HealthInsuranceDetails,
                    HealthInsuranceDetailsRU = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "ru").HealthInsuranceDetails,
                    HealthInsuranceDetailsEN = PomegranateSettingsFromDb.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code == "en").HealthInsuranceDetails,
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
            
            
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").MainTitle = PomegranateSettingsUpdateVM.MainTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").MainTitle = PomegranateSettingsUpdateVM.MainTitleRU;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").MainTitle = PomegranateSettingsUpdateVM.MainTitleEN;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").MainDetails = PomegranateSettingsUpdateVM.MainDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").MainDetails = PomegranateSettingsUpdateVM.MainDetailsRU;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").MainDetails = PomegranateSettingsUpdateVM.MainDetailsEN;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").RhythmTitle = PomegranateSettingsUpdateVM.RhythmTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").RhythmTitle = PomegranateSettingsUpdateVM.RhythmTitleRU;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").RhythmTitle = PomegranateSettingsUpdateVM.RhythmTitleEN;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").RhythmDetails = PomegranateSettingsUpdateVM.RhythmDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").RhythmDetails = PomegranateSettingsUpdateVM.RhythmDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").RhythmDetails = PomegranateSettingsUpdateVM.RhythmDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").BoostTitle = PomegranateSettingsUpdateVM.BoostTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").BoostTitle = PomegranateSettingsUpdateVM.BoostTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").BoostTitle = PomegranateSettingsUpdateVM.BoostTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").BoostDetails = PomegranateSettingsUpdateVM.BoostDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").BoostDetails = PomegranateSettingsUpdateVM.BoostDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").BoostDetails = PomegranateSettingsUpdateVM.BoostDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").HealthInsuranceTitle = PomegranateSettingsUpdateVM.HealthInsuranceTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").HealthInsuranceTitle = PomegranateSettingsUpdateVM.HealthInsuranceTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").HealthInsuranceTitle = PomegranateSettingsUpdateVM.HealthInsuranceTitleAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").HealthInsuranceDetails = PomegranateSettingsUpdateVM.HealthInsuranceDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").HealthInsuranceDetails = PomegranateSettingsUpdateVM.HealthInsuranceDetailsAZ;
            PomegranateSettingsFromVm.PomegranateSettingsLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").HealthInsuranceDetails = PomegranateSettingsUpdateVM.HealthInsuranceDetailsAZ;

            await _pomegranateService.UpdatePomegranateSettings(PomegranateSettingsFromDb, PomegranateSettingsFromVm);
            return RedirectToAction("Index", "Pomegranate");             
        }
    }
}
