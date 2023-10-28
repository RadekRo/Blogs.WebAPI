using Blogs.WebAPI.Domain;

namespace Blogs.WebAPI.Infrastructure
{
    public interface IBlogsRepository
    {
        IEnumerable<Blog> GetBlogs(string? search);
        Blog? GetBlog(int id);
        void CreateBlog(Blog blog);
        bool UpdateBlog(Blog blog);
        bool DeleteBlog(int id);
    }
}
