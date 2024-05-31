using University.WebAPI.Models;

namespace University.WebAPI.Persistance
{
    public class StudentStore
    {
        public static List<Client> Students = new List<Client>()
        {
            new Client() { Id = 1, FirstName = "Jan", LastName = "Nowak", Email="jan.nowak@gmail.com", CreatedAt = DateTime.Now.AddDays(-5)},
            new Client() { Id = 2, FirstName = "Jan", LastName = "Kowalski", Email="jan.kowalski@gmail.com", CreatedAt = DateTime.Now.AddYears(-3)},
        };
    }
}
