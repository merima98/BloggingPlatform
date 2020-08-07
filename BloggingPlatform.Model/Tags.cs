using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingPlatform.Model
{
    public class Tags
    {
        public Tags()
        {
            tags = new List<string>();
        }
        public List<string> tags { get; set; } = new List<string>();
    }
}
