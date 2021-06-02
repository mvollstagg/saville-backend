using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using MediaBalansSaville.Core.Services;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class LangController : Controller
    {
        private readonly ILangService _langService;

        public LangController(ILangService langService)
        {
            this._langService = langService;
        }

        [Route("/cms/dil")]
        public async Task<IActionResult> Index(int count = 100)
        {
            var langs = await _langService.GetAllLangs();
            langs.OrderByDescending(x => x.RecordedAtDate).Take(count).ToList();
            return View(langs);
        }

        [Route("/cms/dil/yarat")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/cms/dil/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LangCreateVM langCreateVM)
        {
            if (!ModelState.IsValid) return View(langCreateVM);

            Lang newLang = new Lang
            {
                Name = langCreateVM.Name.Trim(),
                Code = langCreateVM.Code.Trim().ToLower(),
                SlugUrl = UrlSeoHelper.UrlSeo(langCreateVM.Code.Trim().ToLower()),
                IsActive = langCreateVM.IsActive
            };

            await _langService.CreateLang(newLang);

            return RedirectToAction("Index", "Lang");
        }

        [Route("/cms/dil/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Lang langFromDb = await _langService.GetLangWithId(id);
            if (langFromDb == null) return NotFound();

            LangUpdateVM langUpdateVM = new LangUpdateVM
            {
                Name = langFromDb.Name,
                Code = langFromDb.Code,
                IsActive = langFromDb.IsActive
            };

            return View(langUpdateVM);
        }

        [Route("/cms/dil/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, LangUpdateVM langUpdateVM)
        {
            if (id == 0) return BadRequest();
            Lang langFromDb = await _langService.GetLangWithId(id);
            if (langFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(langUpdateVM);

            Lang langFromVm = new Lang()
            {
                Name = langUpdateVM.Name,
                SlugUrl = UrlSeoHelper.UrlSeo(langUpdateVM.Name.Trim()),
                IsActive = langUpdateVM.IsActive,
            };
            await _langService.UpdateLang(langFromDb, langFromVm);

            return RedirectToAction("Index", "Lang");
        }

        [Route("/cms/dil/kaldir/{id}")]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Lang langFromDb = await _langService.GetLangWithId(id);
            await _langService.DeleteLang(langFromDb);

            return RedirectToAction("Index", "Lang");
        }
    }
}
