using Library.API.DTO;
using Library.API.DTO.Create;

namespace Library.API.Handlers
{
    public interface IBookHandler
    {
        Task<List<BookDto>> GetAllAsync();

        Task<BookDto?> GetByIdAsync(Guid id);

        Task<List<BookDto>> SearchAsync(string term);

        Task<Guid> AddAsync(CreateBookDto dto);

        Task<List<TopRatedBookDto>> GetTopRatedBooksAsync();

        Task<List<BookDto>> SearchByRatingAsync(int minimumRating);
    }
}
