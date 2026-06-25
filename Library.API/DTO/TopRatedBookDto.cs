namespace Library.API.DTO
{
    public class TopRatedBookDto
    {
        public string Title { get; set; }

        public int PublicationYear { get; set; }

        public decimal Rating { get; set; }

        public string AuthorName { get; set; }
    }
}
