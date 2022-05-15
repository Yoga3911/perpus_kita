namespace project_pbo.Models
{
    public class BookModel
    {

        public Int16 BookId { get; set; }
        public string? Title { get; set; }
        public string? Rating { get; set; }
        public string? Isbn { get; set; }
        public Int16 PublisherId { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
