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
        /// <summary>
        /// Get a list of all loanes with status and dates start, return and due to. 
        /// </summary>
        /// <returns>The list of loans</returns>
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

        /// <summary>
        /// Get information about loan status with dates of start loan, return and due to by providing ID.
        /// </summary>
        /// <param name="id">Loan ID</param>
        /// <returns>Status of a loan</returns>
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

        /// <summary>
        /// Create new loan in library.
        /// </summary>
        /// <returns>Create book</returns>
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

        /// <summary>
        /// Delete existing loan from library by providing ID.
        /// </summary>
        /// <param name="id">Loan ID</param>
        /// <returns>Delete loan</returns>
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

        /// <summary>
        /// Update existing loan information by providing ID.
        /// </summary>
        /// <param name="id">Loan ID</param>
        /// <param name="dto">Information which are to be updated</param>
        /// <returns>Update loan information</returns>
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
