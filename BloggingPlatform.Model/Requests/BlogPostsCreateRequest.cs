using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BloggingPlatform.Model.Requests
{
    public class BlogPostsCreateRequest
    {
        [Required(ErrorMessage = "You must enter Title!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must enter Description!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "You must enter Body!")]
        public string Body { get; set; }
        public virtual List<string> Tags { get; set; } = new List<string>();

    }
}
