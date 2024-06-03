using Microsoft.AspNetCore.Mvc;
using University.WebAPI.Dto;
using University.WebAPI.Models;
using University.WebAPI.Persistance;

namespace University.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
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
                    });
                }
                return result;
            }

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
                };

                return Ok(result);
            }

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
                };
                BookStore.Elements.Add(book);

                var routeValues = new { id = book.BookId };
                return CreatedAtRoute("GetBook", routeValues, book);
            }

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
                return NoContent();
            }
    }
}
