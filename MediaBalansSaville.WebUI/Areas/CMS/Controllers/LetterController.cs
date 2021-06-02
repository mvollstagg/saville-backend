using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using MediaBalansSaville.Core.Services;

namespace MediaBalansSaville.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class LetterController : Controller
    {
        private readonly ILetterService _letterService;

        public LetterController(ILetterService letterService)
        {
            _letterService = letterService;
        }

        [Route("/cms/mektublar")]
        public async Task<IActionResult> Index(int count = 100)
        {
            var letters = await _letterService.GetAllLetters();
            return View(letters.OrderByDescending(x => x.RecordedAtDate).Take(count).ToList());
        }

        [Route("/cms/mektublar/kaldir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Letter letterFromDb = await _letterService.GetLetterById(id);
            await _letterService.DeleteLetter(letterFromDb);
            
            return RedirectToAction("Index", "Letter");
        }
    }
}
