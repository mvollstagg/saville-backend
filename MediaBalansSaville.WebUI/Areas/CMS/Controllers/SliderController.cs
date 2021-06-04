
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

            Slider newSlider = new Slider
            {
                PhotoUrl = await _image.UploadAsync(sliderCreateVM.MainPhotoFile, "files", "slider"),
                SlugUrl = "pic",
                IsActive = sliderCreateVM.IsActive
            };

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
            // sliderFromVm.SlugUrl = UrlSeoHelper.UrlSeo(sliderUpdateVM.TitleAZ.Trim());
            sliderFromVm.IsActive = sliderUpdateVM.IsActive;

            if (sliderUpdateVM.MainPhotoFile != null)
            {
                _image.Delete("files", "slider", sliderFromDb.PhotoUrl);
                sliderFromVm.PhotoUrl = await _image.UploadAsync(sliderUpdateVM.MainPhotoFile, "files", "slider");
            }
            
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
            // _image.Delete("files", "slider", sliderFromDb.PhotoUrl);

            return RedirectToAction("Index", "Slider");
        }
    }
}
