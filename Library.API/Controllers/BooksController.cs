using Library.API.DTO.Create;
using Library.API.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController(IBookHandler handler) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await handler.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await handler.GetByIdAsync(id);

            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string term)
        {
            return Ok(await handler.SearchAsync(term));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBookDto dto)
        {
            var id = await handler.AddAsync(dto);

            return Ok(id);
        }

        [HttpGet("top")]
        public async Task<IActionResult> GetTopRatedBooks()
        {
            var result = await handler.GetTopRatedBooksAsync();

            return Ok(result);
        }
    }
}
