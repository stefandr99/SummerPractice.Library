using System.Data;
using Dapper;
using Library.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure.Repositories
{
    public class DapperBookRepository(IConfiguration configuration) : IBookRepository
    {
        private readonly string connectionString = configuration.GetConnectionString("LibraryDb")!;

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            const string sql = """
                SELECT
                    Id,
                    IsDeleted,
                    Title,
                    PublicationYear,
                    Rating,
                    AuthorId
                FROM Books
                """;

            using var connection = CreateConnection();

            var books = await connection.QueryAsync<Book>(sql);

            return books.ToList();
        }

        public async Task<Book?> GetByIdAsync(Guid id)
        {
            const string sql = """
                SELECT
                    Id,
                    IsDeleted,
                    Title,
                    PublicationYear,
                    Rating,
                    AuthorId
                FROM Books
                WHERE Id = @Id
                """;

            using var connection = CreateConnection();

            return await connection.QuerySingleOrDefaultAsync<Book>(
                sql,
                new { Id = id });
        }

        public async Task<List<Book>> SearchAsync(string term)
        {
            const string sql = """
                SELECT
                    Id,
                    IsDeleted,
                    Title,
                    PublicationYear,
                    Rating,
                    AuthorId
                FROM Books
                WHERE Title LIKE '%' + @Term + '%'
                ORDER BY Title
                """;

            using var connection = CreateConnection();

            var books = await connection.QueryAsync<Book>(
                sql,
                new { Term = term });

            return books.ToList();
        }

        public async Task<List<Book>> GetTopRatedBooksAsync()
        {
            const string sql = """
                SELECT
                    Id,
                    IsDeleted,
                    Title,
                    PublicationYear,
                    Rating,
                    AuthorId
                FROM Books
                WHERE PublicationYear > 2010
                  AND Rating >= 4
                ORDER BY Rating DESC
                """;

            using var connection = CreateConnection();

            var books = await connection.QueryAsync<Book>(sql);

            return books.ToList();
        }

        public async Task<List<Book>> SearchByRatingAsync(int minimumRating)
        {
            const string sql = """
                SELECT
                    Id,
                    IsDeleted,
                    Title,
                    PublicationYear,
                    Rating,
                    AuthorId
                FROM Books
                WHERE Rating >= @MinimumRating
                ORDER BY Rating DESC
                """;

            using var connection = CreateConnection();

            var books = await connection.QueryAsync<Book>(
                sql,
                new { MinimumRating = minimumRating });

            return books.ToList();
        }

        public async Task AddAsync(Book entity)
        {
            const string sql = """
                INSERT INTO Books
                (
                    Id,
                    IsDeleted,
                    Title,
                    PublicationYear,
                    Rating,
                    AuthorId
                )
                VALUES
                (
                    @Id,
                    @IsDeleted,
                    @Title,
                    @PublicationYear,
                    @Rating,
                    @AuthorId
                )
                """;

            using var connection = CreateConnection();

            await connection.ExecuteAsync(sql, entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            const string sql = """
                DELETE FROM Books
                WHERE Id = @Id
                """;

            using var connection = CreateConnection();

            await connection.ExecuteAsync(
                sql,
                new { Id = id });
        }

        public Task SaveChangesAsync()
        {
            // Dapper executes immediately.
            return Task.CompletedTask;
        }

        public async Task<List<Book>> GetAllWithAuthorsAsync()
        {
            throw new NotImplementedException();
        }
    }
}