using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KarakasWenAdmin.Models.Entitys
{
    public class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
            PostTag = new HashSet<PostTag>();
        }
        public int Id { get; set; }
        [DisplayName("Resim Adresi")]
        public string PicturePath { get; set; }
        [DisplayName("Başlık")]
        public string Title { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Kısa İçerik")]
        public string ShortContent { get; set; }
        [DisplayName("Tüm İçerik")]
        public string FullContent { get; set; }
        [DisplayName("Kategorisi")]
        public int CategoryId { get; set; }
        [DisplayName("Görüntüleme ")]
        public int ViewCount { get; set; }
        [DisplayName("Aktif mi")]
        public bool IsActive { get; set; }
        [DisplayName("Sil")]
        public bool IsDelete { get; set; }
        [DisplayName("Oluşturma Tarihi")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Güncelleme Tarihi")]
        public DateTime UpdateDate { get; set; }
        [DisplayName("Yoruma Açık mı")]
        public bool AllowComment { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<PostTag> PostTag { get; set; }
    }
}
