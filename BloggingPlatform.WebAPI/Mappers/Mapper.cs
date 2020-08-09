using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BloggingPlatform.Model.Requests;

namespace BloggingPlatform.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.BlogPost, Model.BlogPostCount>();
            CreateMap<Database.BlogPost, Model.BlogPost>();
            CreateMap<BlogPostsCreateRequest, Database.BlogPost>();  
            CreateMap<Database.Tags, Model.Tags>();
        }
    }
}
