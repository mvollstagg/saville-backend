using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaBalansSaville.Entities;
using Microsoft.AspNetCore.Mvc;
using MediaBalansSaville.WebUI.Areas.CMS.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using MediaBalansSaville.Core.Services;

namespace MediaBalansSaville.WebUI.Areas.CMS.Controllers
{
    [Area("CMS")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private IHttpContextAccessor _httpContextAccessor;

        public AccountController(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._userService = userService;
        }

        [Route("/cms")]
        [Route("/cms/hesab/giris")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("Index", "Home");
            return View();
        }

        [Route("/cms")]
        [Route("/cms/hesab/giris")]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var userFromDb = await _userService.UserLogin(loginVM.Email, loginVM.Password);
            
            SetIdentity(userFromDb);
            return RedirectToAction("Index", "Home");
        }
        
        [Route("/cms/hesab/cixis")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        #region ---------User Security
        public async Task<User> GetUser()
        {
            List<Claim> useridentity = GetIdentitiy();
            if (useridentity == null)
                return null;
            if (useridentity.FirstOrDefault(x => x.Type == "id") == null)
                return null;
            Int16 userid = Convert.ToInt16(useridentity.FirstOrDefault(x => x.Type == "id").Value);
            User user =  await _userService.GetUserById(userid);
            return user;
        }
        public void SetIdentity(User user) 
        {
            var claims = new List<Claim> {                
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.UserRoles.FirstOrDefault(x => x.UserId == user.Id).Role.Name),
                new Claim("id",user.Id.ToString())
            };
            var userIdentity = new ClaimsIdentity(claims, "user");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            HttpContext.SignInAsync(principal);

        }
        public List<Claim> GetIdentitiy() 
        {
            List<Claim> checkuser = User.Claims.ToList();
            if (checkuser != null)
                return checkuser;
            return null;
        }        
        #endregion ----------User Security

        public bool IsAjaxRequest(HttpRequest request)
        {
            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
