using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatform.Model.Requests;
using BloggingPlatform.WebAPI.Database;
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
        public ActionResult<List<Model.BlogPostCount>> Get([FromQuery] BlogPostsSearchRequest_byTag request)
        {
            return _blogPostService.Get(request);
        }
    }
}
