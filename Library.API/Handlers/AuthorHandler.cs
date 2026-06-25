using Library.API.DTO;
using Library.API.DTO.Create;
using Library.Infrastructure.Entities;
using Library.Infrastructure.Repositories;

namespace Library.API.Handlers
{
    public class AuthorHandler(IAuthorRepository repository) : IAuthorHandler
    {
        public async Task<List<AuthorDto>> GetAllAsync()
        {
            var authors = await repository.GetAllAsync();

            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
        }

        public async Task<AuthorDto?> GetByIdAsync(Guid id)
        {
            var a = await repository.GetByIdAsync(id);

            if (a == null) return null;

            return new AuthorDto
            {
                Id = a.Id,
                Name = a.Name
            };
        }

        public async Task<List<AuthorDto>> SearchAsync(string term)
        {
            var authors = await repository.SearchAsync(term);

            return authors.Select(a => new AuthorDto
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();
        }

        public async Task<Guid> AddAsync(CreateAuthorDto dto)
        {
            var author = new Author
            {
                Name = dto.Name
            };

            await repository.AddAsync(author);
            await repository.SaveChangesAsync();

            return author.Id;
        }
    }
}
