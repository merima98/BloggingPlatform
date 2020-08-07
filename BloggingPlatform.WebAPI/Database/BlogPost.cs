using System;
using System.Collections.Generic;

namespace BloggingPlatform.WebAPI.Database
{
    public partial class BlogPost
    {
        public BlogPost()
        {
            BlogPostTags = new HashSet<BlogPostTags>();
        }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<BlogPostTags> BlogPostTags { get; set; }

    }
}
