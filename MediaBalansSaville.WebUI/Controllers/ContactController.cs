using MediaBalansSaville.Entities;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.Services.Helpers;
using MediaBalansSaville.WebUI.Models;
using System;
using System.Threading.Tasks;
using MediaBalansSaville.Core.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace MediaBalansSaville.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILetterService _letterService;
        private readonly ILogger<AboutController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        public ContactController(IHttpContextAccessor httpContextAccessor,
                                ILetterService letterService,
                                ILogger<AboutController> logger,
                                IConfiguration configuration)
        {
            this._httpContextAccessor = httpContextAccessor;
            MainHelper.TryToSetLang(_httpContextAccessor);
            _letterService = letterService;
            _configuration = configuration;
            this._logger = logger;
        }
        [Route("/{_lang}/elaqe")]
        public IActionResult Index(string _lang = "en")
        {  
            try
            {           
                ViewBag.Lang = _lang;                
                MainHelper.SetLang(_httpContextAccessor, _lang);
                return View();              
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return View();
            }  
        }

        [Route("/elaqeForm")]
        [Route("/{_lang}/elaqeForm")]
        public async Task<JsonResult> ContactUsPost(string fullName, string phone, string email, string country, string city, string message, string _lang = "en")
        {
            try
            {
                Letter newLetter = new Letter
                {
                    FullName = fullName.Trim(),
                    PhoneNumber = phone.Trim(),
                    Email = email.Trim(),
                    Country = country.Trim(),
                    City = city.Trim(),
                    Message = message,
                    RecordedAtDate = DateTime.Now
                };
                await _letterService.CreateLetter(newLetter);
                return Json(new { status = 200, title = _configuration.GetSection("SuccessTitle").GetSection(_lang).Value , message = _configuration.GetSection("SuccessDetail").GetSection(_lang).Value});
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"contact mail hatasi: {ex.Message}");
                return Json(new { status = 404, title = _configuration.GetSection("ErrorTitle").GetSection(_lang).Value, message = _configuration.GetSection("ErrorDetail").GetSection(_lang).Value });
            }
        }
    }
}
