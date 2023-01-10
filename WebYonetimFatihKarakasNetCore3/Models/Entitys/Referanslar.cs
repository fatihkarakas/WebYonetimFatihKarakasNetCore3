namespace WebYonetimFatihKarakasNetCore3.Models.Entitys
{
    public class Referanslar
    {
        public int Id { get; set; }
        public string? Baslik { get; set; }
        public string? Aciklama { get; set; }
        public string? ResimAdres { get; set; }
        public bool ProjeAktifmi { get; set; }
        public string? CalismaSuresi { get; set; }
        public string? Platform { get; set; }
        public string? Kurum { get; set; }
        public string? LinUrl { get; set; }
        public bool Yayinda { get; set; }
    }
}
