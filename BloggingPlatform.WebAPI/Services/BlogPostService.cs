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

        public BlogPostService(BloggingPlatformContext context  )
        {
            _context = context;
        }

        public  Model.BlogPostCount Get(BlogPostsSearchRequest_byTag searchRequest)
        {
            var query = _context.Tags.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchRequest?.TagName))
            {
                query = query.Where(x => x.Name == searchRequest.TagName);
            }
            var entities = query.ToList(); //filtered tag list
            
              var blogPostTagsQuery = _context.BlogPostTags.AsQueryable();
            if(entities.Count>0)
            foreach (var x in entities)
            {
                blogPostTagsQuery = blogPostTagsQuery.Where(y => y.TagId == x.Id);
            }
            List<BlogPostTags> blogPostTags = new List<BlogPostTags>();
            if (entities.Count > 0)
                blogPostTags = blogPostTagsQuery.ToList();

            List<Model.BlogPost> Posts = new List<Model.BlogPost>();
            var blog_tags = _context.BlogPostTags.ToList();
            var tags = _context.Tags.ToList();

            Model.BlogPostCount PostCount = new Model.BlogPostCount();

            if (blogPostTags.Count==0)
                return PostCount;
              
            else if (blogPostTags.Count>0)
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
            PostCount.BlogPost = Posts;
            PostCount.PostsCount = Posts.Count();
            return PostCount;
        }
    }
}
