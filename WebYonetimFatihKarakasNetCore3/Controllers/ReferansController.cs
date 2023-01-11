using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebYonetimFatihKarakasNetCore3.Models.Entitys;

namespace WebYonetimFatihKarakasNetCore3.Controllers
{
    [Authorize]
    public class ReferansController : Controller
    {
        private readonly KarakasContext karakasContext;
        public ReferansController(KarakasContext karakasContext)
        {
            this.karakasContext = karakasContext;
        }
        public async Task<IActionResult> Index()
        {
            List<Referanslar> referans = await karakasContext.Referanslar.ToListAsync();
            var mesaj = TempData["result"] == null ? string.Empty : TempData["result"];
            ViewData["result"] = mesaj;
            return View(referans);
        }

        public IActionResult ReferansEkle()
        {
            return View();
        }


        public async  Task<IActionResult> Edit(string Id)
        {

            Referanslar  referans = await karakasContext.Referanslar.FirstOrDefaultAsync(xy => xy.Id == Convert.ToInt32(Id));
            if (referans == null)
            {
                return NotFound();
            }
            return View(referans);
        }

        [HttpPost]
        public async  Task<IActionResult> Edit(Referanslar referans)
        {
            if (ModelState.IsValid)
            {
                Referanslar refe = await karakasContext.Referanslar.FirstOrDefaultAsync(x => x.Id == referans.Id);
                if (refe == null)
                {
                    return RedirectToAction(nameof(HomeController), nameof(HomeController.Error));
                }
                refe.Aciklama = referans.Aciklama;
                refe.Kurum = referans.Kurum;
                refe.LinUrl = referans.LinUrl;
                refe.Baslik = referans.Baslik;
                refe.CalismaSuresi = referans.CalismaSuresi;
                refe.Platform = referans.Platform;
                refe.ResimAdres = referans.ResimAdres;
                refe.Yayinda = refe.Yayinda;
                karakasContext.Update(refe);
                var son = karakasContext.SaveChanges();
                if (son == 1)
                {
                    TempData["result"] = "Ok";
                }


            }
            ViewData["sonuc"] = "Referans başarı ile güncellendi";
            return RedirectToAction(nameof(Index));
        }
    }
}
