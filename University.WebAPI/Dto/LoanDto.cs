using University.WebAPI.Models;

namespace University.WebAPI.Dto
{
    public class LoanDto
    {
        public int LoanId { get; set; }
        public Client Client { get; set; }
        public Book Book { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus LoanStatus { get; set; }
    }
}

