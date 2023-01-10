using KarakasWenAdmin.Models.Entitys;
using System.Collections.Generic;

namespace WebYonetimFatihKarakasNetCore3.Models.ModelView
{
    public class YorumMesaj
    {
        public List<Comment> Comments { get; set; }
        public List<Mesajlar> Mesajlars { get; set; }
    }
}
