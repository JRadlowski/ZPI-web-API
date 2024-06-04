using University.WebAPI.Models;

namespace University.WebAPI.Dto
{
    public class CreateLoanDto
    {
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
    }
}

