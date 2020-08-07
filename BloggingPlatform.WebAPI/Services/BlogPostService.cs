using AutoMapper;
using BloggingPlatform.Model.Requests;
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

        public List<Model.BlogPostCount> Get(BlogPostsSearchRequest_byTag searchRequest)
        {
            var query = _context.Tags.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchRequest?.TagName))
            {
                query = query.Where(x => x.Name == searchRequest.TagName);
            }
            var entities = query.ToList(); //filtered tag list
            var blogPostTagsQuery = _context.BlogPostTags.AsQueryable();
            foreach (var x in entities)
            {
                blogPostTagsQuery = blogPostTagsQuery.Where(y => y.TagId == x.Id);
            }
            var blogPostTags = blogPostTagsQuery.ToList();

            List<Model.BlogPostCount> PostCount = new List<Model.BlogPostCount>();
            List<Model.BlogPost> Posts = new List<Model.BlogPost>();
            var blog_tags = _context.BlogPostTags.ToList();
            var tags = _context.Tags.ToList();

            if (blogPostTags.Count>0)
            {
                var posts = _context.BlogPost.AsQueryable();
                foreach (var y in blogPostTags)
                {
                    posts = posts.Where(x => x.Slug == y.Slug);
                }
                 
                var postsList = posts.ToList();
                foreach (var x in postsList)
                {
                    Model.BlogPost blogPost = new Model.BlogPost();
                    blogPost.Slug = x.Slug;
                    blogPost.Title = x.Title;
                    blogPost.Description = x.Description;
                    blogPost.Body = x.Body;
                    blogPost.CreatedAt = x.CreatedAt;
                    blogPost.UpdatedAt = x.UpdatedAt;
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
                    Posts.Add(blogPost);
                }
            }
            else
            {
                var posts = _context.BlogPost.ToList();
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
            }
            Posts.OrderBy(x => x.UpdatedAt); //most recent blog posts 
            PostCount.Add(new Model.BlogPostCount()
            {
                BlogPost = Posts,
                PostsCount = Posts.Count()
            });
            return PostCount;
        }
    }
}
