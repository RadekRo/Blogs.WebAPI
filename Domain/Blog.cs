using System.ComponentModel.DataAnnotations;

namespace Blogs.WebAPI.Domain
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = string.Empty;

        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
