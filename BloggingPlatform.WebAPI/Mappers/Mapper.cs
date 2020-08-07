using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
 

namespace BloggingPlatform.WebAPI.Mappers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.BlogPost, Model.BlogPostCount>();
            CreateMap<Database.Tags, Model.Tags>();
        }
    }
}
