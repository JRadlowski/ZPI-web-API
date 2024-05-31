using Microsoft.AspNetCore.Mvc;
using University.WebAPI.Dto;
using University.WebAPI.Models;
using University.WebAPI.Persistance;

namespace University.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        //[HttpGet]
        //public IEnumerable<StudentDto> Get()
        //{
        //    var students = StudentStore.Students;

        //    List<StudentDto> result = new List<StudentDto>();
        //    foreach (var s in students)
        //    {
        //        result.Add(new StudentDto()
        //        {
        //            Id = s.Id,
        //            FirstName = s.FirstName,
        //            LastName = s.LastName,
        //            Email = s.Email,
        //        });
        //    }
        //    return result;
        //}

        //[HttpGet("{id}")]
        //public StudentDto Get(int id)
        //{
        //    var student = StudentStore.Students
        //        .FirstOrDefault(s => s.Id == id);

        //    var result = new StudentDto()
        //    {
        //        Id = student.Id,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        Email = student.Email,
        //    };

        //    return result;
        //}

        [HttpGet]
        public ActionResult<IEnumerable<ClientDto>> Get()
        {
            var students = StudentStore.Students;

            List<ClientDto> result = new List<ClientDto>();
            foreach (var s in students)
            {
                result.Add(new ClientDto()
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                });
            }
            return Ok(result);
        }

        //[HttpGet("{id}")]
        //public ActionResult<StudentDto> Get(int id)
        //{
        //    var student = StudentStore.Students
        //        .FirstOrDefault(s => s.Id == id);

        //    var result = new StudentDto()
        //    {
        //        Id = student.Id,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        Email = student.Email,
        //    };

        //    return Ok(result);
        //}

        //[HttpGet("{id}")]
        //public ActionResult<StudentDto> Get(int id)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest();
        //    }

        //    var student = StudentStore.Students
        //        .FirstOrDefault(s => s.Id == id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }

        //    var result = new StudentDto()
        //    {
        //        Id = student.Id,
        //        FirstName = student.FirstName,
        //        LastName = student.LastName,
        //        Email = student.Email,
        //    };

        //    return Ok(result);
        //}


        [HttpGet("{id}", Name ="GetStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClientDto> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var student = StudentStore.Students
                .FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            var result = new ClientDto()
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
            };

            return Ok(result);
        }


        //// return Ok()
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Create([FromBody] CreateStudentDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return BadRequest();
        //    }

        //    var id = StudentStore.Students.Max(s => s.Id) + 1;
        //    var student = new Student()
        //    {
        //        Id = id,
        //        FirstName = dto.FirstName,
        //        LastName = dto.LastName,
        //        Email = dto.Email,
        //        CreatedAt = DateTime.UtcNow,
        //    };
        //    StudentStore.Students.Add(student);

        //    return Ok(student);
        //}

        //// Created vs CreatedAtAction vs CreatedAtRoute
        //// https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core

        //return Created() - na sztywno trzeba zbudować url
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateClientDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            var id = StudentStore.Students.Max(s => s.Id) + 1;

            var student = new Client()
            {
                Id = id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                CreatedAt = DateTime.UtcNow,
            };
            StudentStore.Students.Add(student);

            string uri = $"/student/{student.Id}";
            return Created(uri, null);
        }


        ////return CreatedAtAction() - dynamicznie twrozony url
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Create([FromBody] CreateStudentDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return BadRequest();
        //    }

        //    var id = StudentStore.Students.Max(s => s.Id) + 1;

        //    var student = new Student()
        //    {
        //        Id = id,
        //        FirstName = dto.FirstName,
        //        LastName = dto.LastName,
        //        Email = dto.Email,
        //        CreatedAt = DateTime.UtcNow,
        //    };
        //    StudentStore.Students.Add(student);

        //    var actionName = nameof(Get);
        //    var routeValues = new { id = student.Id };
        //    return CreatedAtAction(actionName, routeValues, student);
        //    //return CreatedAtAction(actionName, routeValues, null);
        //}

        //// return CreatedAtRoute() - Dynamicznie tworzony url + obowiazkowa adnotacja Name = dla metody Get zwracającej dopisany obiekt
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public ActionResult Create([FromBody] CreateStudentDto dto)
        //{
        //    if (dto == null)
        //    {
        //        return BadRequest();
        //    }

        //    var id = StudentStore.Students.Max(s => s.Id) + 1;

        //    var student = new Student()
        //    {
        //        Id = id,
        //        FirstName = dto.FirstName,
        //        LastName = dto.LastName,
        //        Email = dto.Email,
        //        CreatedAt = DateTime.UtcNow,
        //    };
        //    StudentStore.Students.Add(student);

        //    var routeValues = new { id = student.Id };
        //    return CreatedAtRoute("GetStudent", routeValues, student);
        //    //return CreatedAtRoute("GetStudent", routeValues, null);
        //}


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id) 
        {
            var student = StudentStore.Students
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            StudentStore.Students.Remove(student);
            
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateClientDto dto)
        {
            if ((dto == null) || (dto.Id == id))
            {
                return BadRequest();
            }

            var student = StudentStore.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) 
            { 
                return NotFound();
            }

            student.FirstName = dto.FirstName;
            student.LastName = dto.LastName;

            return NoContent();
        }
    }
}
