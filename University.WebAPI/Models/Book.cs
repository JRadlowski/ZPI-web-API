namespace University.WebAPI.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string ISBN = @"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$";
        public int PublicationYear { get; set; }
        public StatusOfBook StatusOfBook { get; set; }

    }
}
