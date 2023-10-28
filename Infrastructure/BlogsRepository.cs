using Blogs.WebAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogs.WebAPI.Infrastructure
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly BlogsDbContext _dbContext;

        public BlogsRepository(BlogsDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void CreateBlog(Blog blog)
        {
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
        }

        public bool DeleteBlog(int id)
        {
            var blog = _dbContext.Blogs.SingleOrDefault(b => b.Id == id);
            if (blog is null)
            {
                return false;
            }
            _dbContext.Blogs.Remove(blog);
            _dbContext.SaveChanges();
            return true;
        }

        public Blog? GetBlog(int id)
        {
            return _dbContext.Blogs
                .Include(b => b.Posts)
                .SingleOrDefault(b => b.Id == id); 
        }

        public IEnumerable<Blog> GetBlogs(string? search)
        {
            var query = _dbContext.Blogs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.Title.Contains(search));
            }
            return query.ToList();
        }

        public bool UpdateBlog(Blog blog)
        {
            var blogFromDb = _dbContext.Blogs.SingleOrDefault(b => b.Id == blog.Id);

            if (blogFromDb is null)
            {
                return false;
            }

            blogFromDb.Title = blog.Title;
            _dbContext.SaveChanges();

            return true;
        }
    }
}
