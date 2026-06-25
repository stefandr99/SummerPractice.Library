using Library.API.DTO;
using Library.API.DTO.Create;

namespace Library.API.Handlers
{
    public interface IAuthorHandler
    {
        Task<List<AuthorDto>> GetAllAsync();

        Task<AuthorDto?> GetByIdAsync(Guid id);

        Task<List<AuthorDto>> SearchAsync(string term);

        Task<Guid> AddAsync(CreateAuthorDto dto);
    }
}
