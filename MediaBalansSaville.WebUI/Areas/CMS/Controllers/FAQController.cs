using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Entities;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using MediaBalansSaville.Core.Services;
using MediaBalansSaville.Services;
using System.Collections.Generic;

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
        public async Task<IActionResult> Create(FAQCreateVM FAQCreateVM, List<FAQLang> FAQLangs)
        {
            if (!ModelState.IsValid) return View(FAQCreateVM); 
            
            FAQ newFAQ = new FAQ()
            {
                IsActive = FAQCreateVM.IsActive
            };
            foreach (var item in FAQLangs)
            {
                newFAQ.FAQLangs.Add(new FAQLang()
                {
                    Question = item.Question,
                    Answer = item.Answer,
                    FAQId = newFAQ.Id,
                    LangId = item.LangId
                });
            }
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
                Langs = faqFromDb.FAQLangs.ToList(),
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
                       
            int count = 0;
            foreach (var item in faqFromVm.FAQLangs)
            {                
                item.Question = faqUpdateVM.Langs.ElementAt(count).Question;
                item.Answer = faqUpdateVM.Langs.ElementAt(count).Answer;
                count++;
            }
            faqFromVm.IsActive = faqUpdateVM.IsActive;
            
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
