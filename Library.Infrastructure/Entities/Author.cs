namespace Library.Infrastructure.Entities
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
