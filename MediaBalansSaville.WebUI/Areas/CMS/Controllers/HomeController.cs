using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{
    [Area("CMS")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        [Route("/cms/anasehife")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
