using University.WebAPI.Models;

namespace University.WebAPI.Persistance
{
    public class ClientStore
    {
        public static List<Client> Clients = new List<Client>()
        {
            new Client() { ClientId = 1, FirstName = "Jan", LastName = "Nowak", Email="jan.nowak@gmail.com"},
            new Client() { ClientId = 2, FirstName = "Jan", LastName = "Kowalski", Email="jan.kowalski@gmail.com",},
        };
    }
}
