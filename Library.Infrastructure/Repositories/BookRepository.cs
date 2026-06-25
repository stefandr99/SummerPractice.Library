using Library.Infrastructure.Database;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository(LibraryDbContext context) : IBookRepository
    {
        public async Task<List<Book>> GetAllAsync()
        {
            return [];
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return new();
        }

        public async Task<List<Book>> GetAllWithAuthorsAsync()
        {
            return [];
        }

        public async Task<List<Book>> SearchAsync(string term)
        {
            return [];
        }

        public async Task AddAsync(Book entity)
        {
            await context.Books.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            // TODO
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
