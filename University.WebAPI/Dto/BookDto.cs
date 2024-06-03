using University.WebAPI.Models;

namespace University.WebAPI.Dto
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}

