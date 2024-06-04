using Microsoft.AspNetCore.Mvc;
using University.WebAPI.Dto;
using University.WebAPI.Models;
using University.WebAPI.Persistance;

namespace University.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : Controller
    {
        [HttpGet]
        public IEnumerable<LoanDto> Get()
        {
            var loans = LoanStore.Elements;

            List<LoanDto> result = new List<LoanDto>();
            foreach (var loan in loans)
            {
                result.Add(new LoanDto()
                {
                    LoanId = loan.LoanId,
                    ClientId = loan.ClientId,
                    BookId = loan.BookId,
                    LoanDate = loan.LoanDate,
                    ReturnDate = loan.ReturnDate,
                    DueDate = loan.DueDate,
                    LoanStatus = loan.LoanStatus,
                });
            }
            return result;
        }

        [HttpGet("{id}", Name = "GetLoan")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LoanDto> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var loan = LoanStore.Elements
                .FirstOrDefault(l => l.LoanId == id);

            if (loan == null)
            {
                return NotFound();
            }

            var result = new LoanDto()
            {
                LoanId = loan.LoanId,
                ClientId = loan.ClientId,
                BookId = loan.BookId,
                LoanDate = loan.LoanDate,
                ReturnDate = loan.ReturnDate,
                DueDate = loan.DueDate,
                LoanStatus = loan.LoanStatus,
            };

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateLoanDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var id = LoanStore.Elements.Max(l => l.LoanId) + 1;

            var loan = new Loan()
            {
                LoanId = id,
                ClientId = dto.ClientId,
                BookId = dto.BookId,
                LoanDate = DateTime.UtcNow,
                ReturnDate = dto.ReturnDate,
                DueDate = dto.DueDate,
                LoanStatus = LoanStatus.Active,
            };
            LoanStore.Elements.Add(loan);

            var routeValues = new { id = loan.LoanId };
            return CreatedAtRoute("GetLoan", routeValues, loan);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            var loan = LoanStore.Elements
                .FirstOrDefault(l => l.LoanId == id);

            if (loan == null)
            {
                return NotFound();
            }

            LoanStore.Elements.Remove(loan);
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateLoanDto dto)
        {
            if ((dto == null) || (dto.LoanId != id))
            {
                return BadRequest();
            }

            var loan = LoanStore.Elements.FirstOrDefault(l => l.LoanId == id);
            if (loan == null)
            {
                return NotFound();
            }

            loan.ClientId = dto.ClientId;
            loan.BookId= dto.BookId;
            loan.LoanDate = dto.LoanDate;
            loan.DueDate = dto.DueDate;
            loan.ReturnDate = dto.ReturnDate;
            loan.LoanStatus = dto.LoanStatus;
            return NoContent();
        }
    }
}
