using BloggingPlatform.Model.Requests;
using BloggingPlatform.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatform.WebAPI.Services
{
    public interface IBlogPostService
    {
        List<Model.BlogPostCount> Get(BlogPostsSearchRequest_byTag searchRequest);
    }
}
