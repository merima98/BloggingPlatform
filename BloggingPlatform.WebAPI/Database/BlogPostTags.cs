using System;
using System.Collections.Generic;

namespace BloggingPlatform.WebAPI.Database
{
    public partial class BlogPostTags
    {
        public string Slug { get; set; }
        public int? TagId { get; set; }

        public virtual BlogPost SlugNavigation { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
