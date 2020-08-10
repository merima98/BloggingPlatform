using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BloggingPlatform.WebAPI.Database
{
    public partial class BloggingPlatformContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //Tags
            WebAPI.Database.Tags tag = new WebAPI.Database.Tags()
            {
                Id = 1,
                Name = "AR"
            };
            modelBuilder.Entity<Tags>().HasData(tag);

            WebAPI.Database.Tags tag1 = new WebAPI.Database.Tags()
            {
                Id = 2,
                Name = "iOS"
            };
            modelBuilder.Entity<Tags>().HasData(tag1);

            WebAPI.Database.Tags tag2 = new WebAPI.Database.Tags()
            {
                Id = 3,
                Name = "Angular"
            };
            modelBuilder.Entity<Tags>().HasData(tag2);

            WebAPI.Database.Tags tag3 = new WebAPI.Database.Tags()
            {
                Id = 4,
                Name = ".Net Core"
            };
            modelBuilder.Entity<Tags>().HasData(tag3);

            WebAPI.Database.Tags tag4 = new WebAPI.Database.Tags()
            {
                Id = 5,
                Name = "C++"
            };
            modelBuilder.Entity<Tags>().HasData(tag4);

            WebAPI.Database.Tags tag5 = new WebAPI.Database.Tags()
            {
                Id = 6,
                Name = "HTML5"
            };
            modelBuilder.Entity<Tags>().HasData(tag5);

            WebAPI.Database.Tags tag6 = new WebAPI.Database.Tags()
            {
                Id = 7,
                Name = "Xamarin"
            };
            modelBuilder.Entity<Tags>().HasData(tag6);

            WebAPI.Database.Tags tag7 = new WebAPI.Database.Tags()
            {
                Id = 8,
                Name = "CSS3"
            };
            modelBuilder.Entity<Tags>().HasData(tag7);

            WebAPI.Database.Tags tag8 = new WebAPI.Database.Tags()
            {
                Id = 9,
                Name = "AWS Comprehend"
            };
            modelBuilder.Entity<Tags>().HasData(tag8);

            WebAPI.Database.Tags tag9 = new WebAPI.Database.Tags()
            {
                Id = 10,
                Name = "Android"
            };
            modelBuilder.Entity<Tags>().HasData(tag9);

            //Blog posts
            WebAPI.Database.BlogPost blog = new BlogPost()
            {
                Id= 1,
                Slug = "augmented-reality-ios-application",
                Title = "Augmented Reality iOS Application",
                Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app."
            };
            modelBuilder.Entity<BlogPost>().HasData(blog);


            WebAPI.Database.BlogPost blog1 = new BlogPost()
            {
                Id= 2,
                Slug = "augmented-reality-ios-application-2",
                Title = "Augmented Reality iOS Application 2",
                Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app."
            };
            modelBuilder.Entity<BlogPost>().HasData(blog1);

            WebAPI.Database.BlogPost blog2 = new BlogPost()
            {
                Id= 3,
                Slug = "course-for-begginers-Angular",
                Title = "Course for begginers - Angular",
                Body = "This is the best way to introduce to the Angular",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = "Course where the user can learn the most useful tips and triks while learning Angular"
            };
            modelBuilder.Entity<BlogPost>().HasData(blog2);

            WebAPI.Database.BlogPost blog3 = new BlogPost()
            {
                Id= 4,
                Slug = "course-for-begginers-HTML5-CSS3",
                Title = "Course for begginers - HTML5 and CSS3",
                Body = "This is the best way to introduce to the HTML5 and CSS3",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = "Course where the user can learn the most useful tips and triks for web development applications!"
            };
            modelBuilder.Entity<BlogPost>().HasData(blog3);


            WebAPI.Database.BlogPost blog4 = new BlogPost()
            {
                Id= 5,
                Slug = "course-for-begginers-AWS-Comprehend",
                Title = "Course for begginers - AWS Comprehend",
                Body = "This is the best way to introduce to the train the dataset",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = "Course where the user can learn how to clean unstructured dataset, train it and after that test the dataset!"
            };
            modelBuilder.Entity<BlogPost>().HasData(blog4);

            //Blog posets - tags

            WebAPI.Database.BlogPostTags blogsTags = new BlogPostTags()
            {
                Id = 1,
                SlugId =5,
                TagId = 9
            };
            modelBuilder.Entity<BlogPostTags>().HasData(blogsTags);

            WebAPI.Database.BlogPostTags blogsTags1 = new BlogPostTags()
            {
                Id = 2,
                SlugId = 4,
                TagId = 8
            };
            modelBuilder.Entity<BlogPostTags>().HasData(blogsTags1);

            WebAPI.Database.BlogPostTags blogsTags2 = new BlogPostTags()
            {
                Id = 3,
                SlugId = 4,
                TagId = 6
            };
            modelBuilder.Entity<BlogPostTags>().HasData(blogsTags2);

            WebAPI.Database.BlogPostTags blogsTags3 = new BlogPostTags()
            {
                Id = 4,
                SlugId = 2,
                TagId = 1
            };
            modelBuilder.Entity<BlogPostTags>().HasData(blogsTags3);

            WebAPI.Database.BlogPostTags blogsTags4 = new BlogPostTags()
            {
                Id = 5,
                SlugId = 1,
                TagId = 1
            };
            modelBuilder.Entity<BlogPostTags>().HasData(blogsTags4);


            WebAPI.Database.BlogPostTags blogsTags5 = new BlogPostTags()
            {
                Id = 6,
                SlugId = 1,
                TagId = 2
            };
            modelBuilder.Entity<BlogPostTags>().HasData(blogsTags5);

            WebAPI.Database.BlogPostTags blogsTags6 = new BlogPostTags()
            {
                Id = 7,
                SlugId = 2,
                TagId = 2
            };
            modelBuilder.Entity<BlogPostTags>().HasData(blogsTags6);
        }
    }
}
