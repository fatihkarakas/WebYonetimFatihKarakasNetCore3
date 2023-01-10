using System;
using System.Collections.Generic;

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
        public string PicturePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortContent { get; set; }
        public string FullContent { get; set; }
        public int CategoryId { get; set; }
        public int ViewCount { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool AllowComment { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
        public virtual ICollection<PostTag> PostTag { get; set; }
    }
}
