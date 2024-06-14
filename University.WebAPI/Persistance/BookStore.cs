using University.WebAPI.Models;

namespace University.WebAPI.Persistance
{
    public class BookStore
    {
        public static List<Book> Elements = new List<Book>()
        {
            new Book() { BookId = 1, Author = "Adam Mickiewicz", Title = "Pan Tadeusz", Genre = "Epika", Publisher = "Znak", ISBN = "978-83-240-3201-7", PublicationYear = 1834, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 2, Author = "Adam Mickiewicz", Title = "Dziady III", Genre = "Dramat", Publisher = "Wydawnictwo Literackie", ISBN = "978-83-08-06392-4", PublicationYear = 1832, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 3, Author = "Henryk Sienkiewicz", Title = "Quo Vadis", Genre = "Powieść", Publisher = "Greg", ISBN = "978-83-7327-012-2", PublicationYear = 1896, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 4, Author = "Henryk Sienkiewicz", Title = "Potop", Genre = "Powieść historyczna", Publisher = "Greg", ISBN = "978-83-7512-162-0", PublicationYear = 1886, StatusOfBook = StatusOfBook.Borrowed },
            new Book() { BookId = 5, Author = "Bolesław Prus", Title = "Lalka", Genre = "Powieść", Publisher = "Wydawnictwo MG", ISBN = "978-83-7779-264-4", PublicationYear = 1890, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 6, Author = "Stanisław Lem", Title = "Solaris", Genre = "Science Fiction", Publisher = "Wydawnictwo Literackie", ISBN = "978-83-0805-204-2", PublicationYear = 1961, StatusOfBook = StatusOfBook.Reserved },
            new Book() { BookId = 7, Author = "Juliusz Słowacki", Title = "Kordian", Genre = "Dramat", Publisher = "Wydawnictwo Literackie", ISBN = "978-83-08-03702-5", PublicationYear = 1834, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 8, Author = "Maria Konopnicka", Title = "Nasza szkapa", Genre = "Nowela", Publisher = "Greg", ISBN = "978-83-7512-236-8", PublicationYear = 1890, StatusOfBook = StatusOfBook.Borrowed },
            new Book() { BookId = 9, Author = "Eliza Orzeszkowa", Title = "Nad Niemnem", Genre = "Powieść", Publisher = "Greg", ISBN = "978-83-7327-288-1", PublicationYear = 1888, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 10, Author = "Stefan Żeromski", Title = "Przedwiośnie", Genre = "Powieść", Publisher = "Greg", ISBN = "978-83-7327-271-3", PublicationYear = 1925, StatusOfBook = StatusOfBook.Reserved },
            new Book() { BookId = 11, Author = "Władysław Reymont", Title = "Chłopi", Genre = "Powieść", Publisher = "Greg", ISBN = "978-83-7327-015-3", PublicationYear = 1904, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 12, Author = "Wisława Szymborska", Title = "Wiersze wybrane", Genre = "Poezja", Publisher = "Wydawnictwo Literackie", ISBN = "978-83-08-04892-7", PublicationYear = 1996, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 13, Author = "Czesław Miłosz", Title = "Zniewolony umysł", Genre = "Esej", Publisher = "Znak", ISBN = "978-83-240-4224-3", PublicationYear = 1953, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 14, Author = "Olga Tokarczuk", Title = "Bieguni", Genre = "Powieść", Publisher = "Wydawnictwo Literackie", ISBN = "978-83-08-04401-6", PublicationYear = 2007, StatusOfBook = StatusOfBook.Borrowed },
            new Book() { BookId = 15, Author = "Hanna Krall", Title = "Zdążyć przed Panem Bogiem", Genre = "Reportaż", Publisher = "Wydawnictwo Literackie", ISBN = "978-83-0805-404-6", PublicationYear = 1977, StatusOfBook = StatusOfBook.Reserved },
            new Book() { BookId = 16, Author = "Zofia Nałkowska", Title = "Medaliony", Genre = "Opowiadania", Publisher = "Greg", ISBN = "978-83-7512-104-0", PublicationYear = 1946, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 17, Author = "Bruno Schulz", Title = "Sklepy cynamonowe", Genre = "Opowiadania", Publisher = "Wydawnictwo Literackie", ISBN = "978-83-0805-394-0", PublicationYear = 1934, StatusOfBook = StatusOfBook.Borrowed },
            new Book() { BookId = 18, Author = "Ryszard Kapuściński", Title = "Cesarz", Genre = "Reportaż", Publisher = "Czytelnik", ISBN = "978-83-07-03293-4", PublicationYear = 1978, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 19, Author = "Tadeusz Borowski", Title = "Pożegnanie z Marią", Genre = "Opowiadania", Publisher = "PWN", ISBN = "978-83-01-18721-8", PublicationYear = 1947, StatusOfBook = StatusOfBook.Available },
            new Book() { BookId = 20, Author = "Leopold Tyrmand", Title = "Zły", Genre = "Powieść", Publisher = "Wydawnictwo MG", ISBN = "978-83-7779-616-1", PublicationYear = 1955, StatusOfBook = StatusOfBook.Reserved }
        };
    }
}
