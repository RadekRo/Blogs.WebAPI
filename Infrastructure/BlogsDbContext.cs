using Microsoft.EntityFrameworkCore;
using Blogs.WebAPI.Domain;

namespace Blogs.WebAPI.Infrastructure
{
    public class BlogsDbContext : DbContext
    {
        public DbSet<Blog> Blogs => Set<Blog>();
        public DbSet<Post> Posts => Set<Post>();

        public BlogsDbContext(DbContextOptions<BlogsDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Title = "My first blog"
                },
                new Blog
                {
                    Id = 2,
                    Title = "My second blog"
                }
                );

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Message = "My first message", BlogId = 1 },
                new Post { Id = 2, Message = "My second message", BlogId = 1 }
                );
        }
    }
}
