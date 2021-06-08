using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.Core.Services;
using System.Collections.Generic;
using MediaBalansSaville.Entities;
using MediaBalansSaville.WebUI.Models;
using Microsoft.Extensions.Logging;

namespace MediaBalansSaville.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryLangService _categoryLangService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IHttpContextAccessor httpContextAccessor,
                                 IProductService productService,
                                 ILogger<ProductController> logger,
                                 ICategoryLangService categoryLangService)
        {
            _httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            this._productService = productService;
            _categoryLangService = categoryLangService;
            this._logger = logger;
        }

        [Route("/{_lang}/mehsullar")]
        public async Task<IActionResult> Index(string _lang = "az")
        {   
            try
            {         
                ViewBag.Lang = _lang;
                MainHelper.SetLang(_httpContextAccessor, _lang);
                IEnumerable<Product> products = await _productService.GetAllProducts();
                ProductVM pageVM = new ProductVM()
                {      
                    Products = products.Where(x => x.IsActive == true).OrderByDescending(x => x.RecordedAtDate).Skip(0).Take(10),
                    ProductCategories = await _categoryLangService.GetAllCategoryLangsFor("productall")
                };
                return View(pageVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }  
        }

        [Route("/{_lang}/mehsullar/moreproduct")]
        public async Task<PartialViewResult> LoadMoreProduct(int skipCount, string category, string _lang = "az")
        {
            try
            {
                ViewBag.Lang = _lang;
                MainHelper.SetLang(_httpContextAccessor, _lang);
                IEnumerable<Product> products = await _productService.GetAllProducts();
                products = products.Where(x => x.Category.CategoryLangs.FirstOrDefault(x => x.Lang.Code == _lang).Name == category);

                if (skipCount <= 1) 
                {                
                    return null;
                }
                    
                return PartialView(products.OrderByDescending(x => x.RecordedAtDate).Skip(skipCount).Take(10));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            } 
        }

        [Route("/{_lang}/productfiltered")]
        public async Task<PartialViewResult> GetFilter(string category = "", string filter = "", string _lang = "az")
        {
            try
            {
                ViewBag.Lang = _lang;
                MainHelper.SetLang(_httpContextAccessor, _lang);
                IEnumerable<Product> products = await _productService.GetAllProducts();

                if (!String.IsNullOrEmpty(filter) )
                {                
                    return PartialView(products.Where(x => x.ProductLangs.FirstOrDefault(x => x.Lang.Code == _lang).Name.ToLower().Contains(filter.ToLower())).ToList());
                }
                if (!String.IsNullOrEmpty(category) && category != "All")
                {                
                    return PartialView(products.Where(x => x.Category.CategoryLangs.FirstOrDefault(x => x.Lang.Code == _lang).Name.ToLower().Contains(category.ToLower())).ToList());                
                }
                    
                return PartialView(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            } 
        }

        [Route("/{_lang}/mehsullar/{slugurl}-{urlid}")]
        public async Task<IActionResult> Item(string slugurl, int urlid, string _lang = "az")
        {
            try
            {
                ViewBag.Lang = _lang;
                ViewBag.SlugUrl = slugurl;
                ViewBag.UrlId = urlid;
                MainHelper.SetLang(_httpContextAccessor, _lang);
                if (slugurl == null || urlid == 0) return BadRequest();

                IEnumerable<Product> products = await _productService.GetAllProducts();
                ProductPageVM pageVM = new ProductPageVM();

                Product product = await _productService.GetProductBySlugUrlAndUrlId(slugurl, urlid);
                pageVM.OtherProducts =  products.Where(x => x.Category.CategoryLangs.FirstOrDefault(x => x.Lang.Code == _lang).Name == pageVM.Product.Category.CategoryLangs.FirstOrDefault(x => x.Lang.Code == _lang).Name);
            
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }   
        }
    }
}
