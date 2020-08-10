using System;
using System.Collections.Generic;

namespace BloggingPlatform.WebAPI.Database
{
    public partial class BlogPostTags
    {
        public int Id { get; set; }
        public int? SlugId { get; set; }
        public int? TagId { get; set; }

        public virtual BlogPost Slug { get; set; }
        public virtual Tags Tag { get; set; }
    }
}
