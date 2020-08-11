using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingPlatform.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public tagsController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpGet]
        public ActionResult<Model.Tags> Get( )
        {
            return _tagService.Get();
        }
    }
}
