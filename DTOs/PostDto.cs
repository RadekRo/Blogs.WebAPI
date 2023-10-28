using Blogs.WebAPI.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blogs.WebAPI.DTOs
{
    public class PostDto
    {

        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
