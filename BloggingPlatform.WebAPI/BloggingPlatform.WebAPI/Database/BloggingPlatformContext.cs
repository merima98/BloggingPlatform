using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloggingPlatform.WebAPI.Database
{
    public partial class BloggingPlatformContext : DbContext
    {
        public BloggingPlatformContext()
        {
        }

        public BloggingPlatformContext(DbContextOptions<BloggingPlatformContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPost> BlogPost { get; set; }
        public virtual DbSet<BlogPostTags> BlogPostTags { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=BloggingPlatform;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>(entity =>
            {
                entity.HasKey(e => e.Slug)
                    .HasName("pk_Slug_BlogPosts");

                entity.Property(e => e.Slug).HasMaxLength(200);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            });

            modelBuilder.Entity<BlogPostTags>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("BlogPost_Tags");

                entity.Property(e => e.Slug).HasMaxLength(200);

                entity.HasOne(d => d.SlugNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Slug)
                    .HasConstraintName("fk_Slug");

                entity.HasOne(d => d.Tag)
                    .WithMany()
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("fk_TagId");
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
