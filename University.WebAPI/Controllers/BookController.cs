﻿using Microsoft.AspNetCore.Mvc;
using University.WebAPI.Dto;
using University.WebAPI.Models;
using University.WebAPI.Persistance;

namespace University.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {


        /// <summary>
        /// Get a list of all registered books.
        /// </summary>
        /// <returns>The list of books</returns>
        [HttpGet]
            public IEnumerable<BookDto> Get()
            {
                var books = BookStore.Elements;

                List<BookDto> result = new List<BookDto>();
                foreach (var book in books)
                {
                    result.Add(new BookDto()
                    {
                        BookId = book.BookId,
                        Title = book.Title,
                        Author = book.Author,
                        Genre = book.Genre,
                        StatusOfBook = book.StatusOfBook,
                        PublicationYear = book.PublicationYear,
                        Publisher = book.Publisher
                    });
                }
                return result;
            }
            /// <summary>
            /// Get information about book by providing ID.
            /// </summary>
            /// <param name="id">Book ID</param> 
            /// <returns>Book information</returns>
            [HttpGet("{id}", Name = "GetBook")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult<BookDto> Get(int id)
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var book = BookStore.Elements
                    .FirstOrDefault(b => b.BookId == id);

                if (book == null)
                {
                    return NotFound();
                }

                var result = new BookDto()
                {
                    BookId = book.BookId,
                    Title = book.Title,
                    Author = book.Author,
                    Genre = book.Genre,
                    StatusOfBook = book.StatusOfBook,
                    PublicationYear = book.PublicationYear,
                    Publisher = book.Publisher
                };

                return Ok(result);
            }

            /// <summary>
            /// Create new book in library.
            /// </summary>
            /// <returns>Create book</returns>
            [HttpPost]
            [ProducesResponseType(StatusCodes.Status201Created)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult Create([FromBody] CreateBookDto dto)
            {
                if (dto == null)
                {
                    return BadRequest();
                }

                var id = BookStore.Elements.Max(b => b.BookId) + 1;

                var book = new Book()
                {
                    BookId = id,
                    Title = dto.Title,
                    Author = dto.Author,
                    Genre = dto.Genre,
                    StatusOfBook = dto.StatusOfBook,
                    PublicationYear = dto.PublicationYear,
                    Publisher = dto.Publisher
                };
                BookStore.Elements.Add(book);

                var routeValues = new { id = book.BookId };
                return CreatedAtRoute("GetBook", routeValues, book);
            }
            /// <summary>
            /// Delete existing book from library by providing ID.
            /// </summary>
            /// <param name="id">Book ID</param>
            /// <returns>Delete book</returns>
            [HttpDelete("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            public ActionResult Delete(int id)
            {
                var book = BookStore.Elements
                    .FirstOrDefault(b => b.BookId == id);

                if (book == null)
                {
                    return NotFound();
                }

                BookStore.Elements.Remove(book);
                return NoContent();
            }
            /// <summary>
            /// Update existing book information by providing ID.
            /// </summary>
            /// <param name="id">Book ID</param>
            /// <param name="dto">Information which are to be updated</param>
            /// <returns>Update book information</returns>
            [HttpPut("{id}")]
            [ProducesResponseType(StatusCodes.Status204NoContent)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public ActionResult Update(int id, [FromBody] UpdateBookDto dto)
            {
                if ((dto == null) || (dto.BookId != id))
                {
                    return BadRequest();
                }

                var book = BookStore.Elements.FirstOrDefault(b => b.BookId == id);
                if (book == null)
                {
                    return NotFound();
                }

                book.Title = dto.Title;
                book.Author = dto.Author;
                book.Genre = dto.Genre;
                book.Publisher = dto.Publisher;
                book.PublicationYear = dto.PublicationYear;
                book.StatusOfBook = dto.StatusOfBook;
                return NoContent();
            }
    }
}
