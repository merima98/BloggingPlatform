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
        Model.BlogPostCount Get(BlogPostsSearchRequest_byTag searchRequest);
        Model.BlogPost GetBySlug(string slug);
        bool Delete(string slug);
        Model.BlogPost Insert(BlogPostsCreateRequest request);
    }
}
