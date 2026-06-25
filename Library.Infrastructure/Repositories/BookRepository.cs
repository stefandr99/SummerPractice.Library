using Library.Infrastructure.Database;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository(LibraryDbContext context) : IBookRepository
    {
        public async Task<List<Book>> GetAllAsync()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            return await context.Books
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Book>> GetAllWithAuthorsAsync()
        {
            return [];
        }

        public async Task<List<Book>> SearchAsync(string term)
        {
            // TODO : Implement this method to search for books by title
            return [];
        }

        public async Task AddAsync(Book entity)
        {
            await context.Books.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Books.FindAsync(id);

            if (entity != null)
            {
                context.Books.Remove(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
