using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediaBalansSaville.Data.DAL;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Models;
using System.Linq;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;
using MediaBalansSaville.Core.Services;

namespace MediaBalansSaville.WebUI.Components
{
    public class SiteSettingsViewComponent : ViewComponent
    {
        private readonly ISiteSettingsService _siteSettingsService;
        public SiteSettingsViewComponent(ISiteSettingsService siteSettingsService)
        {
            this._siteSettingsService = siteSettingsService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string lang)
        {         
            if(lang == null) lang = "az";
            SiteSettings siteSettings = await _siteSettingsService.GetSiteSettings();
            ViewData["lang"] = lang;
            return View(siteSettings);
        }
    }
}