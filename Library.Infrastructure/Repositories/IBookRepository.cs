using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<List<Book>> SearchAsync(string term);

        Task<List<Book>> GetAllWithAuthorsAsync();
    }
}
