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

        public BlogPostService(BloggingPlatformContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public Model.BlogPostCount Get(BlogPostsSearchRequest_byTag searchRequest)
        {
            var query = _context.Tags.AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchRequest?.TagName))
            {
                query = query.Where(x => x.Name == searchRequest.TagName);
            }
            var entities = query.ToList(); //filtered tag list

            var blogPostTagsQuery = _context.BlogPostTags.AsQueryable();
            if (entities.Count > 0)
                foreach (var x in entities)
                {
                    blogPostTagsQuery = blogPostTagsQuery.Where(y => y.TagId == x.Id);
                }
            List<BlogPostTags> blogPostTags = new List<BlogPostTags>();
            if (entities.Count > 0)
                blogPostTags = blogPostTagsQuery.ToList();

            List<Model.BlogPost> Posts = new List<Model.BlogPost>();
            var blog_tags = _context.BlogPostTags.Include(x=>x.Slug).ToList();
            var tags = _context.Tags.ToList();

            Model.BlogPostCount PostCount = new Model.BlogPostCount();

            if (blogPostTags.Count > 0)
            {
                var posts = _context.BlogPost.ToList();
                List<Database.BlogPost> temp = new List<Database.BlogPost>();
                foreach (var blogTags in blogPostTags)
                {
                    foreach (var p in posts)
                    {

                        if (p.Slug == blogTags.Slug.Slug)
                        {
                            temp.Add(p);
                        }
                    }
                }
                foreach (var x in temp)
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
                            if (x.Slug == y.Slug.Slug && y.TagId == z.Id)
                            {
                                blogPost.Tags.Add(z.Name);
                            }
                        }
                    }
                    Posts.Add(blogPost);
                }
            }
            if (searchRequest.TagName == null)
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
                                if (x.Slug == y.Slug.Slug && y.TagId == z.Id)
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

        public Model.BlogPost GetBySlug(string slug)
        {
            var entity = _context.BlogPost.Where(x => x.Slug == slug).FirstOrDefault();
            var blogPostsTags = _context.BlogPostTags.Include(x => x.Tag).Include(x=>x.Slug).ToList();
            Model.BlogPost returnValue = new Model.BlogPost();
            if (entity != null)
            {
                returnValue.Body = entity.Body;
                returnValue.CreatedAt = entity.CreatedAt;
                returnValue.Description = entity.Description;
                returnValue.Slug = entity.Slug;
                returnValue.Title = entity.Title;
                returnValue.UpdatedAt = entity.UpdatedAt;

                foreach (var tags in blogPostsTags)
                {
                    if (tags.Slug.Slug == entity.Slug)
                    {
                        returnValue.Tags.Add(tags.Tag.Name);
                    }
                }
            }
            return returnValue;
        }

        public bool Delete(string slug)
        {
            var blogPostTag = _context.BlogPostTags.Include(x=>x.Slug).Where(x => x.Slug.Slug == slug).ToList();

            foreach (var post in blogPostTag)
            {
                _context.BlogPostTags.Remove(post);
                _context.SaveChanges();
            }
            var entity = _context.BlogPost.Where(x => x.Slug == slug).FirstOrDefault();

            if (entity != null)
            {
                _context.BlogPost.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public Model.BlogPost Insert(BlogPostsCreateRequest request)
        {
            var entity = _mapper.Map<Database.BlogPost>(request);
            entity.Slug = RandomString(8);
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            _context.BlogPost.Add(entity);
            _context.SaveChanges();
            foreach (var t in request.Tags)
            {
                Database.Tags temp = new Database.Tags()
                {
                    Name = t
                };
                _context.Tags.Add(temp);
                _context.SaveChanges();
                _context.BlogPostTags.Add(new BlogPostTags()
                {
                    SlugId = entity.Id,
                    TagId = temp.Id
                });
                _context.SaveChanges();
            }
            return _mapper.Map<Model.BlogPost>(entity);
        }

        public Model.BlogPost Update(string slug, BlogPostsUpdateRequest request)
        {
            var entity = _context.BlogPost.Where(x=>x.Slug==slug).FirstOrDefault();
            //List<BlogPostTags> blogPostsTagy_bySlug = _context.BlogPostTags.Include(x=>x.Slug).Where(x => x.Slug.Slug == slug).ToList();
            //List<BlogPostTags> allBlogPostTags = _context.BlogPostTags.Include(x=>x.Slug).ToList();
            //foreach (var item in allBlogPostTags)
            //{
            //    if (item.Slug.Slug == slug)
            //    {
            //        _context.BlogPostTags.Remove(item);
            //        _context.SaveChanges();
            //    }
            //}

            //string tempSlug = null;
            if (entity.Title == request.Title)
            {
                _mapper.Map(request, entity);
                entity.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                //tempSlug = entity.Slug;
            }
            //BlogPost blogPost = new BlogPost();
            if (entity.Title != request.Title)
            {
                //_context.BlogPost.Remove(entity);
                //_context.SaveChanges();

                entity.Body = request.Body;
                entity.CreatedAt = entity.CreatedAt;
                entity.UpdatedAt = DateTime.Now;
                entity.Description = request.Description;
                entity.Slug = RandomString(8);
                entity.Title = request.Title;

                //_context.BlogPost.Add(blogPost);
                //_context.SaveChanges();
                //tempSlug = blogPost.Slug;
            }
            _context.SaveChanges();
            //foreach (var blogTag in blogPostsTagy_bySlug)
            //{
            //    _context.BlogPostTags.Add(new BlogPostTags()
            //    {
            //        SlugId = entity.Id,
            //        TagId = blogTag.TagId
            //    });
            //    _context.SaveChanges();
            //}
            _context.SaveChanges();
            //if (entity.Title != request.Title)
            //    return _mapper.Map<Model.BlogPost>(blogPost);
            return _mapper.Map<Model.BlogPost>(entity);
        }
    }
}
