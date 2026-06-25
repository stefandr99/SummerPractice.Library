using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<List<Author>> SearchAsync(string term);
    }
}
