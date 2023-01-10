using System;

namespace KarakasWenAdmin.Models.Entitys
{
    public class Mesajlar
    {
        public int Id { get; set; }
        public string TamAd { get; set; }
        public string Eposta { get; set; }
        public string Mesaj { get; set; }
        public DateTime Zaman { get; set; }
        public string Ipadres { get; set; }
    }
}
