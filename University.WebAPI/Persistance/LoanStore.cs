using System.Net;
using University.WebAPI.Models;

namespace University.WebAPI.Persistance
{
    public class LoanStore
    {
        public static List<Loan> Elements = new List<Loan>()
        {
            new Loan() { LoanId = 1, ClientId=1, BookId=1 },
            new Loan() { LoanId = 2, ClientId = 1, BookId =2 },
        };
    }
    
}
