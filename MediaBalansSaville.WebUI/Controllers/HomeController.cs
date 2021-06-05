using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediaBalansSaville.WebUI.Models;
using MediaBalansSaville.Services.Helpers;
using Microsoft.AspNetCore.Http;
using MediaBalansSaville.Core.Services;
using MediaBalansSaville.Entities;

namespace MediaBalansSaville.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IProductService _productService;
        private readonly IReceiptService _receiptService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpContextAccessor httpContextAccessor,
                                ISliderService sliderService,
                                IProductService productService,
                                IReceiptService receiptService,
                                ILogger<HomeController> logger)
        {
            this._httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            this._sliderService = sliderService;
            this._productService = productService;
            this._receiptService = receiptService;
            this._logger = logger;
        }

        [Route("/")]
        [Route("/{_lang}")]
        [Route("/{_lang}/anasehife")]
        public async Task<IActionResult> Index(string _lang = "az")
        {   
            try
            {
                ViewBag.Lang = _lang;                
                MainHelper.SetLang(_httpContextAccessor, _lang);
                IEnumerable<Product> products = await _productService.GetAllProducts();
                IEnumerable<Slider> sliders = await _sliderService.GetAllSliders();
                IEnumerable<Receipt> receipts = await _receiptService.GetAllReceipts();  
                Random rnd = new Random();
                HomePageVM homePageVM = new HomePageVM
                {
                    Products = products.Where(x => x.IsActive == true).OrderByDescending(x => x.RecordedAtDate).Take(5),
                    Receipts = receipts.OrderBy(x => rnd.Next(1, receipts.Count())).TakeLast(4),
                    Sliders = sliders.TakeLast(5)
                };
                return View(homePageVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }    
        }
    }
}
