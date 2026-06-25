namespace Library.Infrastructure.Entities
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Title { get; set; }

        public int PublicationYear { get; set; }

        public decimal Rating { get; set; }

        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
