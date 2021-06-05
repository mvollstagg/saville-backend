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
    public class SeoViewComponent : ViewComponent
    {
        private readonly ISeoService _seoService;
        public SeoViewComponent(ISeoService seoService)
        {
            this._seoService = seoService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string page)
        {         
            if(page == null) return null;
            Seo seo = await _seoService.GetSeoByPageName(page);
            return View(seo);
        }   
    }
}