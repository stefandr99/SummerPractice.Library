using Library.API.DTO;
using Library.API.DTO.Create;
using Library.Infrastructure.Entities;
using Library.Infrastructure.Repositories;

namespace Library.API.Handlers
{
    public class BookHandler(IBookRepository repository) : IBookHandler
    {
        public async Task<List<BookDto>> GetAllAsync()
        {
            var books = await repository.GetAllAsync();

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                PublicationYear = b.PublicationYear,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.Name
            }).ToList();
        }

        public async Task<BookDto?> GetByIdAsync(Guid id)
        {
            var b = await repository.GetByIdAsync(id);

            if (b == null) return null;

            return new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                PublicationYear = b.PublicationYear,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.Name
            };
        }

        public async Task<List<BookDto>> SearchAsync(string term)
        {
            var books = await repository.SearchAsync(term);

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                PublicationYear = b.PublicationYear,
                AuthorId = b.AuthorId,
                AuthorName = b.Author?.Name
            }).ToList();
        }

        public async Task<Guid> AddAsync(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                PublicationYear = dto.PublicationYear,
                AuthorId = dto.AuthorId
            };

            await repository.AddAsync(book);
            await repository.SaveChangesAsync();

            return book.Id;
        }
    }
}
