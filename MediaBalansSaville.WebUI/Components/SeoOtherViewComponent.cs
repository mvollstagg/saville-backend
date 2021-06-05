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
    public class SeoOtherViewComponent : ViewComponent
    {
        private readonly ISeoService _seoService;
        public SeoOtherViewComponent(ISeoService seoService)
        {
            this._seoService = seoService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {    
            Seo seo = await _seoService.GetSeoByUniqueId(id);
            return View(seo);
        }   
    }
}