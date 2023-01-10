using KarakasWenAdmin.Models.Entitys;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebYonetimFatihKarakasNetCore3.Models.Entitys;

namespace WebYonetimFatihKarakasNetCore3.Controllers
{


    public class UserAccountController : Controller
    {
        private readonly KarakasContext _karakasContext;
        public UserAccountController(KarakasContext karakasContext)
        {
            _karakasContext = karakasContext;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(UserControl userControl)
        {
            if (ModelState.IsValid)
            {
               
                UserControl users = _karakasContext.UserControl.
                    FirstOrDefault(x => x.UserName == userControl.UserName && x.Password == userControl.Password);
                    
                if (users != null)
                {
                    if (!users.IsActive)
                    {
                        ModelState.AddModelError(nameof(userControl.UserName), "Kullanıcı Hesabınız Pasif edilmiş. Yöneticiniz ile görüşünüz!!");
                        return View(userControl);
                    }

                    List<Claim> claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, users.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, users.FullName ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, users.Role));
                    claims.Add(new Claim("Username", users.UserName));
                    claims.Add(new Claim("TamAd", users.FullName ?? ""));

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                    TempData["result"] = "GirisOk";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı Adınız veya Parolanız hatalı.");
                }
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }


        public IActionResult Profile()
        {
            ProfileInfoLoader();
            return View();
        }

        private void ProfileInfoLoader()
        {
            int userid = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            UserControl? user = _karakasContext.UserControl.SingleOrDefault(x => x.Id == userid);

            ViewData["FullName"] = user == null ? string.Empty : user.FullName;
        }
    }
}

