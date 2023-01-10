using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebYonetimFatihKarakasNetCore3.Models.Entitys;
using WebYonetimFatihKarakasNetCore3.Models.ModelView;

namespace WebYonetimFatihKarakasNetCore3.Controllers
{
    public class YorumlarController : Controller
    {
        private readonly KarakasContext karakasContext;
public YorumlarController(KarakasContext karakasContext)
        {
            this.karakasContext = karakasContext;
        }

        public async Task<IActionResult> Index()
        {
            var yorum = await karakasContext.Comment
                .Include("Post")
                .ToListAsync();
            return View(yorum);
        }

        public async Task<IActionResult> TumList()
        {
            var liste = new YorumMesaj();
            liste.Mesajlars = await karakasContext.Mesajlar.ToListAsync();
            liste.Comments = await karakasContext.Comment.Include("Post").ToListAsync();
            return View(liste);
        }
    }
}
