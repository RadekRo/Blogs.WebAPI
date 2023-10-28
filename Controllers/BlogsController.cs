using AutoMapper;
using Blogs.WebAPI.Domain;
using Blogs.WebAPI.DTOs;
using Blogs.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Blogs.WebAPI.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogsRepository _repository;
        private readonly IMapper _mapper;

        public BlogsController(IBlogsRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET api/blogs
        // GET api/blogs?search=dupa
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<BlogDto>> GetBlogs([FromQuery] string? search)
        {
            var blogs = _repository.GetBlogs(search);
            var blogsDto = _mapper.Map<IEnumerable<BlogDto>>(blogs);

            if (!string.IsNullOrEmpty(search)) 
            { 
                blogsDto = blogsDto
                    .Where(b => b.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            return Ok(blogsDto);

        }
        // GET api/blogs/1
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BlogDetailDto> GetBlog(int id)
        {
            var blog = _repository.GetBlog(id);
            if (blog is null)
            {
                return NotFound();
            }

            var blogDetailDao = _mapper.Map<BlogDetailDto>(blog);

            return Ok(blogDetailDao);
        }
    }    
}