using System.Collections.Generic;

namespace KarakasWenAdmin.Models.Entitys
{
    public class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
