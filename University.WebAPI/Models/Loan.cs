namespace University.WebAPI.Models
{

    public class Loan
    {
        public int LoanId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Book Book { get; set; }

        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DueDate { get; set; }
        public LoanStatus LoanStatus { get; set; }

    }
}
