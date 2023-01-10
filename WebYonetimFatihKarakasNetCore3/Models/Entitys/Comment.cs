using System;
using System.ComponentModel;

namespace KarakasWenAdmin.Models.Entitys
{
    public class Comment
    {
        public int Id { get; set; }
        [DisplayName("Adı Soyadı")]
        public string FullName { get; set; } = "";
        [DisplayName("E-Posta Adresi")]
        public string EmailAddress { get; set; } = string.Empty;
        [DisplayName("İçerikler")]
        public string Content { get; set; } = "";
        [DisplayName("Yayınlansın mı")]
        public bool IsAccept { get; set; }
        [DisplayName("Gönderme Tarihi")]
        public DateTime CreateDate { get; set; }
        public int PostId { get; set; }
        public int ParentId { get; set; }
        [DisplayName("Ip Adresi")]
        public string IpAdres { get; set; } = "";

        public virtual Post Post { get; set; }
    }
}
