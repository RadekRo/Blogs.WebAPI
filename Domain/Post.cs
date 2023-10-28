using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blogs.WebAPI.Domain
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Message { get; set; } = string.Empty;
        public Blog Blog { get; set; } = default!;
        [Required]
        [ForeignKey(nameof(Blog))]
        public int BlogId { get; set; }
    }
}
