using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Library.Infrastructure.Database
{
    public class LibraryDbContextFactory : IDesignTimeDbContextFactory<LibraryDbContext>
    {
        public LibraryDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=127.0.0.1;Database=CourseDb;User Id=sa;Password=p@ssw0rd123;TrustServerCertificate=True;");

            return new LibraryDbContext(optionsBuilder.Options);
        }
    }
}
