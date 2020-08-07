using System;
using System.Collections.Generic;

namespace BloggingPlatform.WebAPI.Database
{
    public partial class Tags
    {
        public Tags()
        {
            BlogPostTags = new HashSet<BlogPostTags>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BlogPostTags> BlogPostTags { get; set; }
    }
}
