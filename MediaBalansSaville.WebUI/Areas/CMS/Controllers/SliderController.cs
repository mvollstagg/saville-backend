
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.Services.Utilities;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using Microsoft.AspNetCore.Authorization;
using MediaBalansSaville.Core.Services;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{

    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class SliderController : Controller
    {
        private readonly ILangService _langService;
        private readonly ISliderService _sliderService;
        private readonly IImage _image;

        public SliderController(ILangService langService,
                                IImage image,
                                ISliderService sliderService)
        {
            this._langService = langService;
            this._sliderService = sliderService;
            this._image = image;
        }

        [Route("/cms/slayder")]
        public async Task<IActionResult> Index(int count = 100)
        {
            return View(await _sliderService.GetAllSliders());
        }

        [Route("/cms/slayder/yarat")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("/cms/slayder/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!ModelState.IsValid) return View(sliderCreateVM);

            if (!_image.IsImageValid(sliderCreateVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(sliderCreateVM);
            }

            Lang azLang = await _langService.GetLangWithCode("az");
            Lang ruLang = await _langService.GetLangWithCode("ru");
            Lang enLang = await _langService.GetLangWithCode("en");

            if (azLang == null && ruLang == null && enLang == null)
            {
                ModelState.AddModelError("", "Öncə məlumat bazasına dillər əlavə edilməlidir !");
                return View(sliderCreateVM);
            }

            Slider newSlider = new Slider
            {
                PhotoUrl = await _image.UploadAsync(sliderCreateVM.MainPhotoFile, "files", "slider"),
                SlugUrl = UrlSeoHelper.UrlSeo(sliderCreateVM.TitleAZ.Trim()),
                IsActive = sliderCreateVM.IsActive
            };
            
            
            SliderLang newSliderLangAZ = new SliderLang
            {
                Title = sliderCreateVM.TitleAZ.Trim(),
                Details = sliderCreateVM.DetailsAZ.Trim(),
                SliderId = newSlider.Id,
                LangId = azLang.Id
            };
            SliderLang newSliderLangRU = new SliderLang
            {
                Title = sliderCreateVM.TitleRU.Trim(),
                Details = sliderCreateVM.DetailsRU.Trim(),
                SliderId = newSlider.Id,
                LangId = ruLang.Id
            };
            SliderLang newSliderLangEN = new SliderLang
            {
                Title = sliderCreateVM.TitleEN.Trim(),
                Details = sliderCreateVM.DetailsEN.Trim(),
                SliderId = newSlider.Id,
                LangId = enLang.Id
            };
            newSlider.SliderLangs.Add(newSliderLangAZ);
            newSlider.SliderLangs.Add(newSliderLangRU);
            newSlider.SliderLangs.Add(newSliderLangEN);

            await _sliderService.CreateSlider(newSlider);

            return RedirectToAction("Index", "Slider");
        }

        [Route("/cms/slayder/duzeliset/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0) return BadRequest();
            Slider sliderFromDb = await _sliderService.GetSliderById(id);
            if (sliderFromDb == null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new SliderUpdateVM
            {
                TitleAZ = sliderFromDb.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Title,
                TitleRU = sliderFromDb.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Title,
                TitleEN = sliderFromDb.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Title,
                DetailsAZ = sliderFromDb.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "az").Details,
                DetailsRU = sliderFromDb.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "ru").Details,
                DetailsEN = sliderFromDb.SliderLangs.FirstOrDefault(x => x.Lang.Code.ToLower() == "en").Details,
                PhotoUrl = sliderFromDb.PhotoUrl,
                IsActive = sliderFromDb.IsActive
            };
            return View(sliderUpdateVM);
        }

        [Route("/cms/slayder/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, SliderUpdateVM sliderUpdateVM)
        {
            if (id == 0) return BadRequest();
            Slider sliderFromDb = await _sliderService.GetSliderById(id);
            Slider sliderFromVm = sliderFromDb;
            if (sliderFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(sliderUpdateVM);

            if (sliderUpdateVM.MainPhotoFile != null)
            {
                if (!_image.IsImageValid(sliderUpdateVM.MainPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(sliderUpdateVM);
                }
            }
            sliderFromVm.SlugUrl = UrlSeoHelper.UrlSeo(sliderUpdateVM.TitleAZ.Trim());
            sliderFromVm.IsActive = sliderUpdateVM.IsActive;

            if (sliderUpdateVM.MainPhotoFile != null)
            {
                _image.Delete("files", "slider", sliderFromDb.PhotoUrl);
                sliderFromVm.PhotoUrl = await _image.UploadAsync(sliderUpdateVM.MainPhotoFile, "files", "slider");
            }

            sliderFromVm.SliderLangs.FirstOrDefault(x =>x.Lang.Code == "az").Title = sliderUpdateVM.TitleAZ.Trim();
            sliderFromVm.SliderLangs.FirstOrDefault(x =>x.Lang.Code == "az").Details = sliderUpdateVM.DetailsAZ.Trim();            
            sliderFromVm.SliderLangs.FirstOrDefault(x =>x.Lang.Code == "ru").Title = sliderUpdateVM.TitleRU.Trim();
            sliderFromVm.SliderLangs.FirstOrDefault(x =>x.Lang.Code == "ru").Details = sliderUpdateVM.DetailsRU.Trim();            
            sliderFromVm.SliderLangs.FirstOrDefault(x =>x.Lang.Code == "en").Title = sliderUpdateVM.TitleEN.Trim();
            sliderFromVm.SliderLangs.FirstOrDefault(x =>x.Lang.Code == "en").Details = sliderUpdateVM.DetailsEN.Trim();
            
            await _sliderService.UpdateSlider(sliderFromDb, sliderFromVm);

            return RedirectToAction("Index", "Slider");
        }

        [Route("/cms/slayder/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();
            Slider sliderFromDb = await _sliderService.GetSliderById(id);
            await _sliderService.DeleteSlider(sliderFromDb);
            _image.Delete("files", "slider", sliderFromDb.PhotoUrl);

            return RedirectToAction("Index", "Slider");
        }
    }
}
