namespace project_pbo.Models
{
    public class LoanModel
    {

        public Int16 BookId { get; set; }
        public string? Title { get; set; }
        public string? Rating { get; set; }
        public string? Isbn { get; set; }
        public string? Description { get; set; }
        public Int16 PublisherId { get; set; }
        public DateTime PublishedDate { get; set; }
        public Int32 LoanId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Int32 AdminId { get; set; }
        public Int16 UserId { get; set; }
        public Int32 BookId2 { get; set; }
        public bool IsReturn { get; set; }
        public Int16 StatusId { get; set; }
    }
}