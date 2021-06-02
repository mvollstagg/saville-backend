using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Entities;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using MediaBalansSaville.Core.Services;
using MediaBalansSaville.Services;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class FAQController : Controller
    {
        private readonly IFAQService _FAQService;
        private readonly ILangService _langService;
        public FAQController(IFAQService FAQService, ILangService langService)
        {
            _FAQService = FAQService;
            _langService = langService;
        }

        [Route("/cms/sorucevap")]
        public async Task<IActionResult> Index(int count = 100)
        {
            var faqs = await _FAQService.GetAllFAQs();
            faqs.OrderByDescending(x => x.RecordedAtDate).Take(count).ToList();
            return View(faqs);
        }

        [Route("/cms/sorucevap/olustur")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/cms/sorucevap/olustur")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FAQCreateVM FAQCreateVM)
        {
            if (!ModelState.IsValid) return View(FAQCreateVM); 
            Lang azLang = await _langService.GetLangWithCode("az");
            Lang ruLang = await _langService.GetLangWithCode("ru");
            Lang enLang = await _langService.GetLangWithCode("en");
            
            FAQ newFAQ = new FAQ()
            {
                IsActive = FAQCreateVM.IsActive
            };
            FAQLang newFAQLangAZ = new FAQLang()
            {
                FAQId = newFAQ.Id,
                LangId = azLang.Id,
                Question = FAQCreateVM.QuestionAZ,
                Answer = FAQCreateVM.AnswerAZ
            };
            FAQLang newFAQLangRU = new FAQLang()
            {
                FAQId = newFAQ.Id,
                LangId = ruLang.Id,
                Question = FAQCreateVM.QuestionRU,
                Answer = FAQCreateVM.AnswerRU
            };
            FAQLang newFAQLangEN = new FAQLang()
            {
                FAQId = newFAQ.Id,
                LangId = enLang.Id,
                Question = FAQCreateVM.QuestionEN,
                Answer = FAQCreateVM.AnswerEN
            };
            newFAQ.FAQLangs.Add(newFAQLangAZ);
            newFAQ.FAQLangs.Add(newFAQLangRU);
            newFAQ.FAQLangs.Add(newFAQLangEN);
            await _FAQService.CreateFAQ(newFAQ);

            return RedirectToAction("Index", "FAQ");
        }

        [Route("/cms/sorucevap/duzelt/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            FAQ faqFromDb = await _FAQService.GetFAQById(id);
            if (faqFromDb == null) return NotFound();

            FAQUpdateVM faqUpdateVM = new FAQUpdateVM
            {
                QuestionAZ = faqFromDb.FAQLangs.FirstOrDefault(x => x.Lang.Code == "az").Question,
                AnswerAZ = faqFromDb.FAQLangs.FirstOrDefault(x => x.Lang.Code == "az").Answer,
                QuestionRU = faqFromDb.FAQLangs.FirstOrDefault(x => x.Lang.Code == "ru").Question,
                AnswerRU = faqFromDb.FAQLangs.FirstOrDefault(x => x.Lang.Code == "ru").Answer,
                QuestionEN = faqFromDb.FAQLangs.FirstOrDefault(x => x.Lang.Code == "en").Question,
                AnswerEN = faqFromDb.FAQLangs.FirstOrDefault(x => x.Lang.Code == "en").Answer,
                IsActive = faqFromDb.IsActive
            };

            return View(faqUpdateVM);
        }

        [Route("/cms/sorucevap/duzelt/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, FAQUpdateVM faqUpdateVM)
        {
            if (id == 0) return BadRequest();
            FAQ faqFromDb = await _FAQService.GetFAQById(id);
            FAQ faqFromVm = faqFromDb;
            if (faqFromDb == null) return NotFound();
            if (!ModelState.IsValid) return View(faqUpdateVM);
                       
            faqFromVm.IsActive = faqUpdateVM.IsActive;
            faqFromVm.FAQLangs.FirstOrDefault(x => x.Lang.Code == "az").Question = faqUpdateVM.QuestionAZ;
            faqFromVm.FAQLangs.FirstOrDefault(x => x.Lang.Code == "az").Answer = faqUpdateVM.AnswerAZ;
            faqFromVm.FAQLangs.FirstOrDefault(x => x.Lang.Code == "ru").Question = faqUpdateVM.QuestionRU;
            faqFromVm.FAQLangs.FirstOrDefault(x => x.Lang.Code == "ru").Answer = faqUpdateVM.AnswerRU;
            faqFromVm.FAQLangs.FirstOrDefault(x => x.Lang.Code == "en").Question = faqUpdateVM.QuestionEN;
            faqFromVm.FAQLangs.FirstOrDefault(x => x.Lang.Code == "en").Answer = faqUpdateVM.AnswerEN;
            
            await _FAQService.UpdateFAQ(faqFromDb, faqFromVm);

            return RedirectToAction("Index", "FAQ");
        }

        [Route("/cms/sorucevap/kaldir")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            FAQ faqFromDb = await _FAQService.GetFAQById(id);
            await _FAQService.DeleteFAQ(faqFromDb);

            return RedirectToAction("Index", "FAQ");
        } 
    }
}
