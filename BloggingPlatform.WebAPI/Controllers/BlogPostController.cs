using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatform.Model.Requests;
//using BloggingPlatform.WebAPI.Database;
using BloggingPlatform.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }
        [HttpGet]
        public ActionResult< Model.BlogPostCount> Get([FromQuery] BlogPostsSearchRequest_byTag request)
        {
            return _blogPostService.Get(request);
        }

        [HttpGet("{slug}")]
        public ActionResult<Model.BlogPost> GetBySlug( string slug)
        {
            return _blogPostService.GetBySlug(slug);
        }


        [HttpDelete("{slug}")]
        public bool Delete(string slug)
        {
            return _blogPostService.Delete(slug);
        }
        [HttpPost]
        public Model.BlogPost Insert(BlogPostsCreateRequest request)
        {
            return _blogPostService.Insert(request);
        }
    }
}
