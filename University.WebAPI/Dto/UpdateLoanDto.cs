using University.WebAPI.Models;

namespace University.WebAPI.Dto
{
    public class UpdateLoanDto
    {
        public int LoanId { get; set; }
        public int ClientId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus LoanStatus { get; set; }
    }
}
