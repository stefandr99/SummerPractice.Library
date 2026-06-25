using Library.API.DTO.Create;
using Library.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController(IAuthorHandler handler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await handler.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await handler.GetByIdAsync(id);

            if (author == null) return NotFound();

            return Ok(author);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string term)
        {
            return Ok(await handler.SearchAsync(term));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorDto dto)
        {
            var id = await handler.AddAsync(dto);

            return Ok(id);
        }
    }
}
