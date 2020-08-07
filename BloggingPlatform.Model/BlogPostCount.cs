using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingPlatform.Model
{
    public class BlogPostCount
    {
        public BlogPostCount()
        {
            BlogPost = new List<BlogPost>();
        }
        public List<Model.BlogPost> BlogPost { get; set; }
        public int PostsCount { get; set; }
    }
}
