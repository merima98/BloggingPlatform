using AutoMapper;
using BloggingPlatform.Model;
using BloggingPlatform.WebAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatform.WebAPI.Services
{
    public class TagService : ITagService
    {
        private readonly BloggingPlatformContext _bloggingContext;
        private readonly IMapper _mapper;
        public TagService(BloggingPlatformContext bloggingContext, IMapper mapper)
        {
            _bloggingContext = bloggingContext;
            _mapper = mapper;
        }
        public Model.Tags Get()
        {
            var result = _bloggingContext.Tags.ToList();
            Model.Tags tags_ = new Model.Tags();
            List<string> tags = new List<string>();
            foreach (var x in result)
            {
                tags.Add(x.Name);

            }
            tags_.tags = tags;
            return tags_;
        }
    }
}
