using AutoMapper;
using BloggingPlatform.WebAPI.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatform.WebAPI.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly BloggingPlatformContext _context;
        private readonly IMapper _mapper;

        public BlogPostService(BloggingPlatformContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Model.BlogPostCount> Get()
        {
            List<Model.BlogPostCount> PostCount = new List<Model.BlogPostCount>();
            List<Model.BlogPost> Posts = new List<Model.BlogPost>();
          
            var posts= _context.BlogPost.ToList();
            var blog_tags = _context.BlogPostTags.ToList();
            var tags = _context.Tags.ToList();

            foreach (var x in posts)
            {
                Model.BlogPost blogPost = new Model.BlogPost();
                blogPost.Slug = x.Slug;
                blogPost.Title = x.Title;
                blogPost.Description = x.Description;
                blogPost.Body = x.Body;
                blogPost.CreatedAt = x.CreatedAt;
                blogPost.UpdatedAt = x.UpdatedAt;
                if (blog_tags.Count() > 0)
                {
                    foreach (var y in blog_tags)
                    {
                        foreach (var z in tags)
                        {
                            if (x.Slug == y.Slug && y.TagId == z.Id)
                            {
                                blogPost.Tags.Add(z.Name);
                            }
                        }
                    }
                }
                Posts.Add(blogPost);
            }
            PostCount.Add(new Model.BlogPostCount()
            {
                BlogPost = Posts,
                PostsCount = Posts.Count()
            });
            return PostCount;
        }
    }
}
