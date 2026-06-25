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
            return await context.Books
                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<List<Book>> SearchAsync(string term)
        {
            return await context.Books
                .Where(x => x.Title.Contains(term))
                .OrderBy(x => x.Title)
                .ToListAsync();
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

        public async Task<List<Book>> GetTopRatedBooksAsync()
        {
            return await context.Books
                .Include(x => x.Author)
                .Where(x => x.PublicationYear > 2010)
                .Where(x => x.Rating >= 4)
                .OrderByDescending(x => x.Rating)
                .ToListAsync();
        }

        public async Task<List<Book>> SearchByRatingAsync(int minimumRating)
        {
            return await context.Books
                .FromSqlRaw("""
                                SELECT
                                    Id,
                                    IsDeleted,
                                    Title,
                                    PublicationYear,
                                    Rating,
                                    AuthorId
                                FROM Books
                                WHERE Rating >= {0}
                            """, minimumRating)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}