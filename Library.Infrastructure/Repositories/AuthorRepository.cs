using Library.Infrastructure.Database;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository(LibraryDbContext context) : IAuthorRepository
    {
        public async Task<List<Author>> GetAllAsync()
        {
            return await context.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await context.Authors
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Author>> SearchAsync(string term)
        {
            return [];
        }

        public async Task AddAsync(Author entity)
        {
            var id = await context.Authors.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Authors.FindAsync(id);

            if (entity != null)
            {
                context.Authors.Remove(entity);
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
