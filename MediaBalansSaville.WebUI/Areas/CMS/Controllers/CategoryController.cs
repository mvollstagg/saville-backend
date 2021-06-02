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
    public class CategoryController : Controller
    {
        private readonly ILangService _langService;
        private readonly ICategoryService _categoryService;

        public CategoryController(  ILangService langService,
                                    ICategoryService categoryService)
        {
            this._langService = langService;
            this._categoryService = categoryService;
        }

        [Route("/cms/kateqoriya")]
        public async Task<IActionResult> Index(int count = 10)
        {
            var categories = await _categoryService.GetAllCategories();
            categories.OrderByDescending(x => x.RecordedAtDate).Take(count).ToList();
            return View(categories);
        }

        [Route("/cms/kateqoriya/yarat")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/cms/kateqoriya/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM categoryCreateVM)
        {
            if (!ModelState.IsValid) return View(categoryCreateVM);
            
            Lang azLang = await _langService.GetLangWithCode("az");
            Lang ruLang = await _langService.GetLangWithCode("ru");
            Lang enLang = await _langService.GetLangWithCode("en");

            if (azLang == null || ruLang == null || enLang == null)
            {
                ModelState.AddModelError("", "Öncə məlumat bazasına dillər əlavə edilməlidir !");
                return View(categoryCreateVM);
            }   

            Category newCategory = new Category()
            {
                SlugUrl = UrlSeoHelper.UrlSeo(categoryCreateVM.NameAZ.Trim()),
                IsActive = categoryCreateVM.IsActive,
                IsProduct = categoryCreateVM.IsProduct,
                IsReceipt = categoryCreateVM.IsReceipt
            };

            CategoryLang newCategoryLangAZ = new CategoryLang
            {
                Name = categoryCreateVM.NameAZ.Trim(),
                CategoryId = newCategory.Id,
                LangId = azLang.Id
            };
            CategoryLang newCategoryLangRU = new CategoryLang
            {
                Name = categoryCreateVM.NameRU.Trim(),
                CategoryId = newCategory.Id,
                LangId = ruLang.Id
            };
            CategoryLang newCategoryLangEN = new CategoryLang
            {
                Name = categoryCreateVM.NameEN.Trim(),
                CategoryId = newCategory.Id,
                LangId = enLang.Id
            };
            
            newCategory.CategoryLangs.Add(newCategoryLangAZ);
            newCategory.CategoryLangs.Add(newCategoryLangRU);
            newCategory.CategoryLangs.Add(newCategoryLangEN);
            await _categoryService.CreateCategory(newCategory);

            return RedirectToAction("Index", "Category");
        }

        [Route("/cms/kateqoriya/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Category categoryFromDb = await _categoryService.GetCategoryById(id);
            if (categoryFromDb == null) return NotFound();

            CategoryUpdateVM categoryUpdateVM = new CategoryUpdateVM
            {
                NameAZ = categoryFromDb.CategoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Name,
                NameRU = categoryFromDb.CategoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Name,
                NameEN = categoryFromDb.CategoryLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Name,
                IsActive = categoryFromDb.IsActive,
                IsProduct = categoryFromDb.IsProduct,
                IsReceipt = categoryFromDb.IsReceipt
            };

            return View(categoryUpdateVM);
        }

        [Route("/cms/kateqoriya/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, CategoryUpdateVM categoryUpdateVM)
        {
            if (id == 0) return BadRequest();
            Category categoryFromDb = await _categoryService.GetCategoryById(id);
            if (categoryFromDb == null) return NotFound();
            if (!ModelState.IsValid) return View(categoryUpdateVM);
            
            Category categoryFromVm = new Category()
            {
                SlugUrl = UrlSeoHelper.UrlSeo(categoryUpdateVM.NameAZ.Trim()),
                IsActive = categoryUpdateVM.IsActive,
                IsProduct = categoryUpdateVM.IsProduct,
                IsReceipt = categoryUpdateVM.IsReceipt,
                CategoryLangs = categoryFromDb.CategoryLangs
            };
            categoryFromVm.CategoryLangs.FirstOrDefault(x => x.Lang.Code == "az").Name = categoryUpdateVM.NameAZ;
            categoryFromVm.CategoryLangs.FirstOrDefault(x => x.Lang.Code == "ru").Name = categoryUpdateVM.NameRU;
            categoryFromVm.CategoryLangs.FirstOrDefault(x => x.Lang.Code == "en").Name = categoryUpdateVM.NameEN;
            await _categoryService.UpdateCategory(categoryFromDb, categoryFromVm);

            return RedirectToAction("Index", "Category");
        }

        [Route("/cms/kateqoriya/kaldir/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Category categoryFromDb = await _categoryService.GetCategoryById(id);
            await _categoryService.DeleteCategory(categoryFromDb);

            return RedirectToAction("Index", "Category");
        }
    }
}
