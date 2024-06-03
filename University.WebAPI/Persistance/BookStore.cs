using University.WebAPI.Models;

namespace University.WebAPI.Persistance
{
    public class BookStore
    {
        public static List<Book> Elements = new List<Book>()
        {
            new Book() { BookId = 1, Author = "Mickiewicz",  Title="Pan Tadeusz", Genre="Epika"},
            new Book() { BookId = 2, Author = "Mickiewicz", Title= "Dziady III", Genre="Drama"},
        };
    }
}
