using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingPlatform.Model.Requests
{
    public class BlogPostsUpdateRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}
