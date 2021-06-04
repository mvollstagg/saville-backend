
using System.Collections.Generic;
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
    public class AboutSettingsController : Controller
    {
        private readonly IAboutSettingservice _aboutSettingservice;
        private readonly ILangService _langService;
        private readonly IImage _image;

        public AboutSettingsController(IAboutSettingservice aboutSettingservice,
                                    ILangService langService,
                                    IImage image)
        {
            this._langService = langService;
            this._aboutSettingservice = aboutSettingservice;
            _image = image;
        }
        
        [Route("/cms/haqqimizdaparametrleri")]
        public async Task<IActionResult> Index()
        {            
            AboutSettings AboutSettingsFromDb = await _aboutSettingservice.GetAboutSettings();
            AboutSettingsVM AboutSettingsUpdateVM = new AboutSettingsVM();
            if (AboutSettingsFromDb == null)
            {
                Lang azLang = await _langService.GetLangWithCode("az");
                Lang ruLang = await _langService.GetLangWithCode("ru");
                Lang enLang = await _langService.GetLangWithCode("en");

                AboutSettingsFromDb = new AboutSettings();
                
                AboutSettingsLang newAboutSettingsLangAZ = new AboutSettingsLang
                {
                    AboutSettingsId = AboutSettingsFromDb.Id,
                    LangId = azLang.Id                    
                };
                AboutSettingsLang newAboutSettingsLangRU = new AboutSettingsLang
                {
                    AboutSettingsId = AboutSettingsFromDb.Id,
                    LangId = ruLang.Id                    
                };
                AboutSettingsLang newAboutSettingsLangEN = new AboutSettingsLang
                {
                    AboutSettingsId = AboutSettingsFromDb.Id,
                    LangId = enLang.Id                    
                };
                AboutSettingsFromDb.AboutSettingsLangs.Add(newAboutSettingsLangAZ);
                AboutSettingsFromDb.AboutSettingsLangs.Add(newAboutSettingsLangRU);
                AboutSettingsFromDb.AboutSettingsLangs.Add(newAboutSettingsLangEN);
                await _aboutSettingservice.CreateAboutSettings(AboutSettingsFromDb);
                
                return RedirectToAction("Index", "AboutSettings");
            }
            else
            {
                AboutSettingsVM settingsVM = new AboutSettingsVM
                {
                    AboutSettingsLangs = AboutSettingsFromDb.AboutSettingsLangs.ToList(),
                    Certificates = AboutSettingsFromDb.AboutSettingsCertificates.ToList(),
                    Items = AboutSettingsFromDb.AboutSettingsItems.ToList()
                };
                
                return View(settingsVM);
            } 
        }

        [Route("/cms/haqqimizdaparametrleri/duzeliset")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(AboutSettingsVM AboutSettingsUpdateVM)
        {            
            AboutSettings AboutSettingsFromDb = await _aboutSettingservice.GetAboutSettings();
            AboutSettings AboutSettingsFromVm = AboutSettingsFromDb;
            if (!ModelState.IsValid) return View(AboutSettingsUpdateVM);            
            
            int count = 0;
            foreach (var item in AboutSettingsFromVm.AboutSettingsLangs)
            {                
                item.OurStory = AboutSettingsUpdateVM.AboutSettingsLangs.ElementAt(count).OurStory;
                item.OurMission = AboutSettingsUpdateVM.AboutSettingsLangs.ElementAt(count).OurMission;
                item.OurVision = AboutSettingsUpdateVM.AboutSettingsLangs.ElementAt(count).OurVision;
                item.WhySaville = AboutSettingsUpdateVM.AboutSettingsLangs.ElementAt(count).WhySaville;
                count++;
            }

            await _aboutSettingservice.UpdateAboutSettings(AboutSettingsFromDb, AboutSettingsFromVm);
            return RedirectToAction("Index", "AboutSettings");             
        }

        #region  Certificates
        [Route("/cms/sertifika/yarat")]
        public IActionResult CreateCertificate()
        {
            return View();
        }

        [Route("/cms/sertifika/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCertificate(CertificateCreateVM certificateCreateVM)
        {
            if (!ModelState.IsValid) return View(certificateCreateVM);

            if (!_image.IsImageValid(certificateCreateVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(certificateCreateVM);
            }
            AboutSettings AboutSettingsFromDb = await _aboutSettingservice.GetAboutSettings();

            AboutSettingsCertificate newCertificate = new AboutSettingsCertificate
            {
                AboutSettingsId = AboutSettingsFromDb.Id,
                PhotoUrl = await _image.UploadAsync(certificateCreateVM.MainPhotoFile, "files", "aboutsettings"),
                IsActive = certificateCreateVM.IsActive
            };

            await _aboutSettingservice.CreateCertificate(newCertificate);

            return RedirectToAction("Index", "AboutSettings");
        }

        [Route("/cms/sertifika/duzeliset/{id}")]
        public async Task<IActionResult> UpdateCertificate(int id)
        {
            if (id == 0) return BadRequest();
            AboutSettingsCertificate certificateFromDb = await _aboutSettingservice.GetCertificateById(id);
            if (certificateFromDb == null) return NotFound();

            CertificateUpdateVM certificateUpdateVM = new CertificateUpdateVM
            {                
                PhotoUrl = certificateFromDb.PhotoUrl,
                IsActive = certificateFromDb.IsActive
            };
            return View(certificateUpdateVM);
        }

        [Route("/cms/sertifika/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCertificate(int id, CertificateUpdateVM certificateUpdateVM)
        {
            if (id == 0) return BadRequest();
            AboutSettingsCertificate certificateFromDb = await _aboutSettingservice.GetCertificateById(id);
            AboutSettingsCertificate certificateFromVm = certificateFromDb;
            if (certificateFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(certificateUpdateVM);

            if (certificateUpdateVM.MainPhotoFile != null)
            {
                if (!_image.IsImageValid(certificateUpdateVM.MainPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(certificateUpdateVM);
                }
            }
            certificateFromVm.IsActive = certificateUpdateVM.IsActive;

            if (certificateUpdateVM.MainPhotoFile != null)
            {
                _image.Delete("files", "aboutsettings", certificateFromDb.PhotoUrl);
                certificateFromVm.PhotoUrl = await _image.UploadAsync(certificateUpdateVM.MainPhotoFile, "files", "aboutsettings");
            }
            await _aboutSettingservice.UpdateCertificate(certificateFromDb, certificateFromVm);

            return RedirectToAction("Index", "AboutSettings");            
        }

        [Route("/cms/sertifika/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            if (id == 0) return BadRequest();
            AboutSettingsCertificate certificateFromDb = await _aboutSettingservice.GetCertificateById(id);
            await _aboutSettingservice.DeleteCertificate(certificateFromDb);
            _image.Delete("files", "aboutsettings", certificateFromDb.PhotoUrl);

            return RedirectToAction("Index", "AboutSettings");
        }
        #endregion

        #region  Items
        [Route("/cms/parametr/yarat")]
        public IActionResult CreateItem()
        {
            return View();
        }

        [Route("/cms/parametr/yarat")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(ASItemCreateVM itemCreateVM, List<AboutSettingsItemLang> itemLangs)
        {
            if (!ModelState.IsValid) return View(itemCreateVM);

            if (!_image.IsImageValid(itemCreateVM.MainPhotoFile))
            {
                ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                return View(itemCreateVM);
            }
            AboutSettings AboutSettingsFromDb = await _aboutSettingservice.GetAboutSettings();

            AboutSettingsItem newItem = new AboutSettingsItem
            {
                AboutSettingsId = AboutSettingsFromDb.Id,
                PhotoUrl = await _image.UploadAsync(itemCreateVM.MainPhotoFile, "files", "aboutsettings"),
                IsActive = itemCreateVM.IsActive
            };
            foreach (var item in itemLangs)
            {
                newItem.AboutSettingsItemLangs.Add(new AboutSettingsItemLang()
                {
                    Title = item.Title,
                    Details = item.Details,
                    AboutSettingsItemId = newItem.Id,
                    LangId = item.LangId
                });
            }

            await _aboutSettingservice.CreateItem(newItem);

            return RedirectToAction("Index", "AboutSettings");
        }

        [Route("/cms/parametr/duzeliset/{id}")]
        public async Task<IActionResult> UpdateItem(int id)
        {
            if (id == 0) return BadRequest();
            AboutSettingsItem itemFromDb = await _aboutSettingservice.GetItemteById(id);
            if (itemFromDb == null) return NotFound();

            ASItemUpdateVM itemUpdateVM = new ASItemUpdateVM
            {          
                Langs = itemFromDb.AboutSettingsItemLangs.ToList(),
                PhotoUrl = itemFromDb.PhotoUrl,
                IsActive = itemFromDb.IsActive
            };
            return View(itemUpdateVM);
        }

        [Route("/cms/parametr/duzeliset/{id}")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateItem(int id, ASItemUpdateVM itemUpdateVM)
        {
            if (id == 0) return BadRequest();
            AboutSettingsItem itemFromDb = await _aboutSettingservice.GetItemteById(id);
            AboutSettingsItem itemFromVm = itemFromDb;
            if (itemFromDb == null) return NotFound();

            if (!ModelState.IsValid) return View(itemUpdateVM);

            if (itemUpdateVM.MainPhotoFile != null)
            {
                if (!_image.IsImageValid(itemUpdateVM.MainPhotoFile))
                {
                    ModelState.AddModelError("", "Fayl .jpg/jpeg formatında və maksimum 3MB həcmində olmalıdır !");
                    return View(itemUpdateVM);
                }
            }
            int count = 0;
            foreach (var item in itemFromVm.AboutSettingsItemLangs)
            {                
                item.Title = itemUpdateVM.Langs.ElementAt(count).Title;
                item.Details = itemUpdateVM.Langs.ElementAt(count).Details;
                count++;
            }
            itemFromVm.IsActive = itemUpdateVM.IsActive;

            if (itemUpdateVM.MainPhotoFile != null)
            {
                _image.Delete("files", "aboutsettings", itemFromDb.PhotoUrl);
                itemFromVm.PhotoUrl = await _image.UploadAsync(itemUpdateVM.MainPhotoFile, "files", "aboutsettings");
            }
            await _aboutSettingservice.UpdateItem(itemFromDb, itemFromVm);

            return RedirectToAction("Index", "AboutSettings");            
        }

        [Route("/cms/parametr/kaldir/{id}")]
        // [HttpDelete]
        public async Task<IActionResult> DeleteItem(int id)
        {
            if (id == 0) return BadRequest();
            AboutSettingsItem itemFromDb = await _aboutSettingservice.GetItemteById(id);
            await _aboutSettingservice.DeleteItem(itemFromDb);
            _image.Delete("files", "aboutsettings", itemFromDb.PhotoUrl);

            return RedirectToAction("Index", "AboutSettings");
        }
        #endregion
    }
}
