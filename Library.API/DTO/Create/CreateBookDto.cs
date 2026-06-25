namespace Library.API.DTO.Create
{
    public class CreateBookDto
    {
        public string Title { get; set; }

        public int PublicationYear { get; set; }

        public Guid AuthorId { get; set; }
    }
}
