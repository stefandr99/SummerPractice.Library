using Library.Infrastructure.Database;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository(LibraryDbContext context) : IAuthorRepository
    {
        public async Task<List<Author>> GetAllAsync()
        {
            return [];
        }

        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return new();
        }

        public async Task<List<Author>> SearchAsync(string term)
        {
            return [];
        }

        public async Task AddAsync(Author entity)
        {
            await context.Authors.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var author = await context.Authors
                .Include(x => x.Books)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (author == null)
            {
                return;
            }

            author.IsDeleted = true;

            foreach (var book in author.Books)
            {
                book.IsDeleted = true;
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
