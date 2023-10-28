namespace Blogs.WebAPI.DTOs
{
    public class BlogDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IEnumerable<PostDto> Posts { get; set; } = Enumerable.Empty<PostDto>();
    }
}
