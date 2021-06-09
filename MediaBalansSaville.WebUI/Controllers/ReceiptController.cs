
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.Core.Services;
using MediaBalansSaville.WebUI.Models;
using Microsoft.Extensions.Logging;

namespace MediaBalansSaville.WebUI.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IReceiptService _receiptService;
        private readonly IProductService _productService;
        private readonly ICategoryLangService _categoryLangService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ReceiptController> _logger;

        public ReceiptController(IHttpContextAccessor httpContextAccessor,
                                IReceiptService receiptService,
                                ICategoryLangService categoryLangService,
                                ILogger<ReceiptController> logger,
                                IProductService productService)
        {
            _httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            this._receiptService = receiptService;
            _productService = productService;
            _categoryLangService = categoryLangService;
            this._logger = logger;
        }
        [Route("/{_lang}/reseptler")]
        public async Task<IActionResult> Index( string _lang = "en", int page = 1)
        {    
            try
            {       
                ViewBag.Lang = _lang;               
                MainHelper.SetLang(_httpContextAccessor, _lang);
                IEnumerable<Receipt> receipts = await _receiptService.GetAllReceipts();
                ReceiptPageVM receiptPageVM = new ReceiptPageVM()
                {      
                    Receipts = receipts.OrderByDescending(x => x.RecordedAtDate).Skip(0).Take(8),         
                    ReceiptCategories = await _categoryLangService.GetAllCategoryLangsFor("receiptall")
                };
                return View(receiptPageVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            } 
        }

        [Route("/{_lang}/morereceipt")]
        public async Task<PartialViewResult> LoadMoreReceipt(int skipCount, string _lang = "en")
        {
            try
            {
                ViewBag.Lang = _lang;
                MainHelper.SetLang(_httpContextAccessor, _lang);
                IEnumerable<Receipt> receipts = await _receiptService.GetAllReceipts();

                if (skipCount <= 1) 
                {                
                    return null;
                }
                    
                return PartialView(receipts.OrderByDescending(x => x.RecordedAtDate).Skip(skipCount).Take(8));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            } 
        }

        [Route("/{_lang}/receiptfiltered")]
        public async Task<PartialViewResult> GetFilter(string category = "", string filter = "", string _lang = "en")
        {
            try
            {
                ViewBag.Lang = _lang;
                MainHelper.SetLang(_httpContextAccessor, _lang);
                IEnumerable<Receipt> receipts = await _receiptService.GetAllReceipts();

                if (!String.IsNullOrEmpty(filter) )
                {                
                    return PartialView(receipts.Where(x => x.ReceiptLangs.FirstOrDefault(x => x.Lang.Code == _lang).Title.ToLower().Contains(filter.ToLower())).ToList());
                }
                if (!String.IsNullOrEmpty(category) && category != "All")
                {                
                    return PartialView(receipts.Where(x => x.Category.CategoryLangs.FirstOrDefault(x => x.Lang.Code == _lang).Name.ToLower().Contains(category.ToLower())).ToList());                
                }
                    
                return PartialView(receipts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            } 
        }

        [Route("/{_lang}/reseptler/{slugurl}-{urlid}")]
        public async Task<IActionResult> Item(string slugurl, int urlid, string _lang = "en")
        {
            try
            {
                ViewBag.Lang = _lang;
                ViewBag.SlugUrl = slugurl;
                ViewBag.UrlId = urlid;
                MainHelper.SetLang(_httpContextAccessor, _lang);
                if (slugurl == null || urlid == 0) return BadRequest();

                ReceiptItemPageVM pageVM = new ReceiptItemPageVM()
                {
                    Receipt = await _receiptService.GetReceiptBySlugUrlAndUrlId(slugurl, urlid)                    
                };
                
                List<Product> products = new List<Product>();
                string[] values = pageVM.Receipt.ProductValues.Split(',');
                foreach (var value in values)
                {
                    Product product = await _productService.GetProductById(Convert.ToInt16(value));
                    if(product != null)
                        products.Add(product);
                }
                pageVM.Products = products;
                pageVM.OtherReceipts = await _receiptService.GetAllReceipts();
                pageVM.OtherReceipts.TakeLast(4);
                return View(pageVM);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            } 
        }

        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
