using KarakasWenAdmin.Models.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebYonetimFatihKarakasNetCore3.Models;
using WebYonetimFatihKarakasNetCore3.Models.Entitys;

namespace WebYonetimFatihKarakasNetCore3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly KarakasContext karakasContext;

        public HomeController(ILogger<HomeController> logger, KarakasContext karakasContext)
        {
            _logger = logger;
            this.karakasContext = karakasContext;
        }

        public async Task<IActionResult> Index()
        {

            List<Post> gonderiler = await karakasContext.Post
               .Include("Category")
               .Include("Comment")
               .ToListAsync();
            var mesaj = TempData["result"] == null ? string.Empty : TempData["result"];
            ViewData["result"] = mesaj;
            if (gonderiler != null)
            {

                return View(gonderiler);
            }

            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Edit(string Id)
        {

            Post gonderi = await karakasContext.Post.SingleAsync(xy => xy.Id == Convert.ToInt32(Id));
            if (gonderi == null)
            {
                return NotFound();
            }
            return View(gonderi);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Post post)
        {
            post.UpdateDate  = DateTime.Now;
            var tarih = post.CreateDate;
            if (ModelState.IsValid)
            {
                karakasContext.Update(post);
                await karakasContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {

                return RedirectToAction("Error");
            }

        }

        [Authorize]
        public  IActionResult GonderiEkle()
        {
            List<Category> categories = karakasContext.Category
                .Where(x=> x.IsActive)
                .ToList();
            ViewBag.Categories = categories;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GonderiEkle(Post gonderi)
        {
            if (ModelState.IsValid)
            {
                gonderi.CreateDate = DateTime.Now;
                gonderi.UpdateDate = DateTime.Now;
                Post p = gonderi;
                karakasContext.Add(p);
                 var sonuc =await  karakasContext.SaveChangesAsync();
                if (sonuc==1)
                {
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Hata = "Hata oluştu";
            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            ViewData["result"] = "1";
             return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Privacy(string testveri)
        {
            ViewData["result"] = testveri;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
