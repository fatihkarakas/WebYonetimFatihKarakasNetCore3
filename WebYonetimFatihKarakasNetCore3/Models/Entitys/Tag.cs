using System.Collections.Generic;

namespace KarakasWenAdmin.Models.Entitys
{
    public class Tag
    {
        public Tag()
        {
            PostTag = new HashSet<PostTag>();
        }

        public int Id { get; set; }
        public string TagName { get; set; }

        public virtual ICollection<PostTag> PostTag { get; set; }
    }
}
