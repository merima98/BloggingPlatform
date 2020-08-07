using System;
using System.Collections.Generic;

namespace BloggingPlatform.WebAPI.Database
{
    public partial class Tags
    {
        //public Tags()
        //{
        //    BlogPost = new HashSet<BlogPost>();
        //}
        public int Id { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<BlogPost> BlogPost { get; set; }
    }
}
