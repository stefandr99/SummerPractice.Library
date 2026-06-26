using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Database
{
    public class LibraryDbContext(DbContextOptions<LibraryDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var bookEntity = modelBuilder.Entity<Book>();
            
            bookEntity
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            bookEntity
                .Property(x => x.Rating)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Author>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
